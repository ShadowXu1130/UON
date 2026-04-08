using Microsoft.Extensions.DependencyInjection;
using UON;

namespace UON;

/// <summary>
/// Represents the cross-platform root of the application.
/// Responsible for managing the application lifecycle and bootstrapping the core UI architecture.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application instance.
    /// Loads the compiled XAML resources and global dictionaries defined in App.xaml.
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Overrides the default window creation process to set up the application's visual root.
    /// </summary>
    /// <param name="activationState">The application's activation state and context.</param>
    /// <returns>A new Window instance containing the AppShell.</returns>
    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Instantiates the AppShell as the root view of the application.
        // AppShell provides the foundational URI-based routing and visual hierarchy (e.g., flyouts, tabs).
        return new Window(new AppShell());
    }
}