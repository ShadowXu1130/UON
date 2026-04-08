namespace UON;

/// <summary>
/// Defines the visual hierarchy and routing structure of the application.
/// Acts as the central hub for URI-based navigation.
/// </summary>
public partial class AppShell : Shell
{
    /// <summary>
    /// Initializes the application shell and registers dynamic navigation routes.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();

        // [ROUTE REGISTRATION]
        // Registers pages that are NOT part of the primary visual hierarchy (like tabs or flyouts)
        // so they can be navigated to programmatically using Shell.Current.GoToAsync().
        Routing.RegisterRoute("SettingsPage", typeof(Views.SettingsPage));

        // Note: If you implement the ScannerPage for the QR code feature later, 
        // you MUST register it here as well, like this:
        // Routing.RegisterRoute("ScannerPage", typeof(Views.ScannerPage));
    }
}