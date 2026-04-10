using System;

namespace UON;

/// <summary>
/// A global static class used to maintain the user's session state across the application.
/// By using variables instead of hardcoded strings, the application remains flexible 
/// and adheres to professional software engineering standards.
/// </summary>
public static class UserSession
{
    /// <summary>
    /// Gets or sets the full name of the currently authenticated user.
    /// Default is "Guest" to avoid hardcoding personal names in the source code.
    /// </summary>
    public static string UserName { get; set; } = "Guest";

    /// <summary>
    /// Gets or sets the university email address of the current user.
    /// This is populated dynamically during the login process.
    /// </summary>
    public static string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether a user is currently logged in.
    /// Used by the AuthService and UI layers to manage application flow.
    /// </summary>
    public static bool IsLoggedIn { get; set; } = false;

    /// <summary>
    /// Clears all current user session data and resets the state.
    /// This must be called during the Logout process to ensure security and data privacy.
    /// </summary>
    public static void Clear()
    {
        UserName = "Guest";
        Email = string.Empty;
        IsLoggedIn = false;
    }
}