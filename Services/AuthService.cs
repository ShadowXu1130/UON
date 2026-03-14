
using Microsoft.Identity.Client;
using Microsoft.Maui.ApplicationModel;

namespace UON.Services;

public class AuthService
{
    private readonly string ClientId = "7255804a-8899-4c8a-895d-067eb23c02d1";
    private readonly string TenantId = "common";

    private IPublicClientApplication _pca;

    public AuthService()
    {
        _pca = PublicClientApplicationBuilder.Create(ClientId)
            .WithAuthority($"https://login.microsoftonline.com/{TenantId}")
            .WithRedirectUri("http://localhost")
            .Build();
    }

    public async Task<AuthenticationResult?> LoginAsync()
    {
        var scopes = new[] { "User.Read" };

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

        var result = await _pca.AcquireTokenInteractive(scopes)
            .WithSystemWebViewOptions(systemWebViewOptions)
            .ExecuteAsync();

        if (result != null)
        {
            return result;
        }

        return null;
    }
}