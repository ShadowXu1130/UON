using Microsoft.Extensions.Logging;

namespace UON;

/// <summary>
/// The central bootstrapper class for the .NET MAUI application.
/// Responsible for configuring the app builder, registering core services, fonts, and logging behaviors.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Creates and configures the MAUI application instance.
    /// Acts as the main initialization point before the App lifecycle begins.
    /// </summary>
    /// <returns>A fully built and configured MauiApp ready for execution.</returns>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            // Registers global custom fonts to ensure consistent typography and UI design across all platforms.
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Enables detailed console logging strictly in the Development (Debug) environment.
        // This preprocessor directive ensures that debugging logs are automatically stripped out 
        // during Release builds to optimize production performance and prevent sensitive data leaks.
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}