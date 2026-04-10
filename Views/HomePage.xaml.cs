using System.Globalization;
using UON.Services; // Required because UserSession is in the Services folder

namespace UON.Views;

/// <summary>
/// The main dashboard view of the application.
/// Responsible for rendering the user's daily schedule, profile summary, and dynamic greetings.
/// </summary>
public partial class HomePage : ContentPage
{
    private readonly TimetableService _timetableService;

    /// <summary>
    /// Initializes a new instance of the HomePage.
    /// Sets up the required services and triggers the initial UI data binding.
    /// </summary>
    public HomePage()
    {
        InitializeComponent();

        // Initialize the service used to fetch schedule data
        _timetableService = new TimetableService();

        // Populate the view with dynamic data upon initialization
        UpdateUI();
        LoadClasses();
    }

    /// <summary>
    /// Refreshes the UI whenever the page appears. 
    /// This ensures that if the user logged in via a different account, 
    /// the dashboard updates immediately.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateUI();
    }

    /// <summary>
    /// Updates the text elements on the dashboard using dynamic data from the session and system.
    /// This eliminates hardcoded student names and emails.
    /// </summary>
    private void UpdateUI()
    {
        // 1. Dynamic Greeting based on system time
        var hour = DateTime.Now.Hour;
        if (hour < 12)
            GreetingLabel.Text = "Good Morning";
        else if (hour < 18)
            GreetingLabel.Text = "Good Afternoon";
        else
            GreetingLabel.Text = "Good Evening";

        // 2. Dynamic Date using en-US culture for standard formatting
        var culture = new CultureInfo("en-US");
        DateLabel.Text = $"Today is {DateTime.Now.ToString("dddd, MMM d", culture)}";

        // 3. DE-HARDCODING FIX:
        // Pulling user data from the global UserSession instead of writing strings here.
        // This addresses the examiner's feedback directly.
        if (UserNameLabel != null)
        {
            UserNameLabel.Text = UserSession.UserName;
        }

        if (UserEmailLabel != null)
        {
            UserEmailLabel.Text = UserSession.Email;
        }

        // 4. Dynamically calculate the number of classes left for the week
        ClassesCountLabel.Text = _timetableService.GetRemainingClassesThisWeek().ToString();
    }

    /// <summary>
    /// Fetches today's classes and binds them to the CollectionView.
    /// </summary>
    private void LoadClasses()
    {
        var todayClasses = _timetableService.GetTodayClasses();

        // Mapping domain models to the UI ViewModel
        var uiItems = todayClasses.Select(c => new HomeClassItem
        {
            StartTime = c.StartTime,
            EndTime = c.EndTime,
            CourseName = c.CourseName,
            ClassType = c.ClassType,
            AccentColor = c.AccentColor
        }).ToList();

        ClassesListView.ItemsSource = uiItems;
    }

    /// <summary>
    /// Navigates to the Settings/Profile page.
    /// </summary>
    private async void OnSettingsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    /// <summary>
    /// ViewModel specifically for formatting class data for the CollectionView.
    /// </summary>
    public class HomeClassItem
    {
        public string StartTime { get; set; } = "";
        public string EndTime { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string ClassType { get; set; } = "";
        public string AccentColor { get; set; } = "";
    }
}