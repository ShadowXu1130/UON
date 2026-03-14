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
}