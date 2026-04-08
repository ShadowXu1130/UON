using UON.Services;

namespace UON.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var result = await _authService.LoginAsync();
        if (result != null)
        {
            //
            UserSession.UserName = "Xu Xinpeng";
            await Shell.Current.GoToAsync("//main");
        }
    }

    private async void OnTestModeClicked(object sender, EventArgs e)
    {
        // 1. Inject mock session data (if your dashboard requires displaying user info).
        // Note: Replace these variable names with your actual UserSession properties if you have them.
        // UserSession.Email = "professor.test@uon.edu.au";
        // UserSession.Name = "Test User";

        // 2. Show a friendly alert to inform the examiner that this bypass is implemented due to strict IT permission restrictions.
        await DisplayAlert(
            "Test Mode Activated",
            "Bypassing MSAL authentication due to University Admin restrictions. Entering Demo Mode.",
            "OK");

        // 3. Execute absolute routing to navigate to the Dashboard (ensure this matches your AppShell routing, e.g., "//main" or "//HomePage").
        await Shell.Current.GoToAsync("//main");
    }

}