namespace UON.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        // 绑定当前登录的用户信息
        UserNameLabel.Text = "Xinpeng Xu";
        UserEmailLabel.Text = "Xinpeng.Xu@psba.edu.sg";
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // 返回上一页
    }

    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlertAsync(
            "Log Out",
            "Are you sure you want to log out?",
            "Yes",
            "Cancel");

        if (confirm)
        {
            // 1. 清空本地存储的登录状态 (如果有)
            // SecureStorage.RemoveAll();

            // 2. 跳转回登录页面并清空导航堆栈
            // "//LoginPage" 路径会强制重置整个 App 的状态
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}