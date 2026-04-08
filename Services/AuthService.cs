using Microsoft.Identity.Client;
using Microsoft.Maui.ApplicationModel;

namespace UON.Services;

/// <summary>
/// Handles authentication processes using Microsoft Authentication Library (MSAL).
/// Responsible for managing the public client application and acquiring security tokens.
/// </summary>
public class AuthService
{
    // The Application (client) ID assigned by the Azure portal when the app was registered.
    private readonly string ClientId = "7255804a-8899-4c8a-895d-067eb23c02d1";

    // "common" allows any Microsoft account (personal, work, or school) to attempt login.
    private readonly string TenantId = "common";

    // Represents the MSAL public client application instance.
    private IPublicClientApplication _pca;

    /// <summary>
    /// Initializes a new instance of the AuthService class and configures the MSAL client.
    /// </summary>
    public AuthService()
    {
        // Build the public client application with the specified Client ID, Authority, and Redirect URI.
        _pca = PublicClientApplicationBuilder.Create(ClientId)
            .WithAuthority($"https://login.microsoftonline.com/{TenantId}")
            .WithRedirectUri("http://localhost")
            .Build();
    }

    /// <summary>
    /// Initiates the interactive login flow using the system's default web browser.
    /// </summary>
    /// <returns>An AuthenticationResult containing the access token and user profile, or null if login fails/cancels.</returns>
    public async Task<AuthenticationResult?> LoginAsync()
    {
        // Define the permissions requested from the user (read-only access to their basic profile).
        var scopes = new[] { "User.Read" };

        // Configure the system browser options to ensure the MSAL login page opens correctly within the MAUI environment.
        var systemWebViewOptions = new SystemWebViewOptions
        {
            OpenBrowserAsync = async (Uri uri) =>
            {
                // UI operations (like opening a browser) must be dispatched to the Main Thread.
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                });
            }
        };

        // Attempt to acquire the token interactively (prompts the user to log in).
        var result = await _pca.AcquireTokenInteractive(scopes)
            .WithSystemWebViewOptions(systemWebViewOptions)
            .ExecuteAsync();

        // Return the authentication result if successful.
        if (result != null)
        {
            return result;
        }

        return null;
    }
}