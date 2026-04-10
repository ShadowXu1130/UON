using Microsoft.Identity.Client;
using Microsoft.Maui.ApplicationModel;

namespace UON.Services;

/// <summary>
/// Handles authentication processes using the Microsoft Identity Platform (MSAL.NET).
/// Responsible for managing the public client application and acquiring secure identity tokens.
/// </summary>
public class AuthService
{
    // The Application (client) ID registered in the Azure portal.
    private readonly string ClientId = "7255804a-8899-4c8a-895d-067eb23c02d1";

    // "common" allows any organizational or personal Microsoft account to sign in.
    private readonly string TenantId = "common";

    // Represents the MSAL public client application instance.
    private readonly IPublicClientApplication _pca;

    /// <summary>
    /// Initializes the AuthService and configures the MSAL client with platform-specific settings.
    /// </summary>
    public AuthService()
    {
        // Build the public client application. 
        // Note: Using msal{ClientId}://auth is the standard for native MAUI apps to handle redirects.
        _pca = PublicClientApplicationBuilder.Create(ClientId)
            .WithAuthority($"https://login.microsoftonline.com/{TenantId}")
            .WithRedirectUri($"http://localhost")
            .Build();
    }

    /// <summary>
    /// Initiates the interactive OAuth 2.0 login flow.
    /// Extracts user data dynamically from the token to avoid hardcoding personal information.
    /// </summary>
    /// <returns>An AuthenticationResult if successful; otherwise, null.</returns>
    public async Task<AuthenticationResult?> LoginAsync()
    {
        // Permissions requested: Basic profile access.
        var scopes = new[] { "User.Read" };

        try
        {
            // Configure the system browser for the interactive login popup.
            var systemWebViewOptions = new SystemWebViewOptions
            {
                OpenBrowserAsync = async (Uri uri) =>
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                    });
                }
            };

            // Execute the interactive token acquisition.
            var result = await _pca.AcquireTokenInteractive(scopes)
                .WithSystemWebViewOptions(systemWebViewOptions)
                .ExecuteAsync();

            // DE-HARDCODING LOGIC: 
            // If the login is successful, we dynamically populate our global UserSession.
            if (result != null && result.Account != null)
            {
                // Pulling the real name and email from the Microsoft Identity claims.
                UserSession.Email = result.Account.Username;
                UserSession.UserName = result.ClaimsPrincipal.FindFirst("name")?.Value ?? "UON Student";
                UserSession.IsLoggedIn = true;
            }

            return result;
        }
        catch (MsalClientException ex)
        {
            // Specifically handles cases where the user cancels the login window.
            System.Diagnostics.Debug.WriteLine($"MSAL User Cancelled: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Catch-all for network errors or configuration issues.
            System.Diagnostics.Debug.WriteLine($"Authentication Error: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Signs the user out by clearing the MSAL token cache and resetting the global session.
    /// </summary>
    public async Task LogoutAsync()
    {
        var accounts = await _pca.GetAccountsAsync();
        foreach (var account in accounts)
        {
            await _pca.RemoveAsync(account);
        }

        // Reset the dynamic session data.
        UserSession.Clear();
    }
}