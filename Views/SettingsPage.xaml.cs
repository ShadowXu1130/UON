using Microsoft.Maui.Devices; // Required for Haptic Feedback

namespace UON.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        // Bind current logged-in user information
        UserNameLabel.Text = "Xinpeng Xu";
        UserEmailLabel.Text = "Xinpeng.Xu@psba.edu.sg";
    }

    /// <summary>
    /// Handles the back navigation to the previous page.
    /// </summary>
    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// Handles the Log Out process with Haptic Feedback and Confirmation.
    /// </summary>
    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        // 1. Trigger Native Haptic Feedback (Vibration)
        // This provides immediate physical confirmation to the user.
        if (HapticFeedback.Default.IsSupported)
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.Click);
        }

        // 2. Show the Log Out confirmation dialog
        bool confirm = await DisplayAlert(
            "Log Out",
            "Are you sure you want to log out?",
            "Yes",
            "Cancel");

        if (confirm)
        {
            // 3. Clear session or local storage if necessary
            // Example: SecureStorage.Default.RemoveAll();

            // 4. Navigate back to the LoginPage and reset the navigation stack
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}