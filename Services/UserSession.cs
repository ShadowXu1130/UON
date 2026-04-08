using System;
using System.Collections.Generic;
using System.Text;

namespace UON.Services;

/// <summary>
/// A global static class used to maintain the user's session state across the application.
/// Currently initialized with mock data to support the Demo Mode bypass.
/// </summary>
public static class UserSession
{
    /// <summary>
    /// Gets or sets the full name of the currently authenticated (or demo) user.
    /// </summary>
    public static string UserName { get; set; } = "Xu Xinpeng";

    /// <summary>
    /// Gets or sets the university email address of the current user.
    /// </summary>
    public static string Email { get; set; } = "Xinpeng.Xu@psba.edu.sg";

    /// <summary>
    /// Clears the current user session data. 
    /// This should be called during the Logout process to prevent data leakage.
    /// </summary>
    public static void Clear()
    {
        UserName = string.Empty;
        Email = string.Empty;
    }
}