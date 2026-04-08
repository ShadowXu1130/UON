using System.Globalization;
using UON.Services;

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
    /// Updates the static and dynamic text elements on the dashboard, 
    /// such as the time-based greeting, current date, and remaining class count.
    /// </summary>
    private void UpdateUI()
    {
        var hour = DateTime.Now.Hour;

        // Determine the appropriate greeting based on the device's local time
        if (hour < 12)
            GreetingLabel.Text = "Good Morning";
        else if (hour < 18)
            GreetingLabel.Text = "Good Afternoon";
        else
            GreetingLabel.Text = "Good Evening";

        // Force en-US culture for a standardized date format (e.g., "Friday, Jan 30")
        var culture = new CultureInfo("en-US");
        DateLabel.Text = $"Today is {DateTime.Now.ToString("dddd, MMM d", culture)}";

        // Display current user context (Mock data for demo mode)
        UserEmailLabel.Text = "Xinpeng.Xu@uon.edu.au";

        // Dynamically calculate and display the number of classes left for the current week
        ClassesCountLabel.Text = _timetableService.GetRemainingClassesThisWeek().ToString();
    }

    /// <summary>
    /// Retrieves today's scheduled classes from the service layer and projects them 
    /// into a format suitable for the CollectionView data binding.
    /// </summary>
    private void LoadClasses()
    {
        // Fetch the raw schedule data for today (automatically calculates the current academic week)
        var todayClasses = _timetableService.GetTodayClasses();

        // Project the domain models (ScheduleItem) into ViewModels (HomeClassItem) specifically for UI rendering
        var uiItems = todayClasses.Select(c => new HomeClassItem
        {
            StartTime = c.StartTime,
            EndTime = c.EndTime,
            CourseName = c.CourseName,
            ClassType = c.ClassType,
            AccentColor = c.AccentColor
        }).ToList();

        // Bind the projected list to the XAML CollectionView
        ClassesListView.ItemsSource = uiItems;
    }

    /// <summary>
    /// Event handler for navigating to the Settings/Profile page.
    /// </summary>
    private async void OnSettingsTapped(object sender, EventArgs e)
    {
        // Use Shell absolute or relative routing to navigate without stacking pages infinitely
        await Shell.Current.GoToAsync("SettingsPage");
    }

    /// <summary>
    /// A localized Data Transfer Object (DTO) / ViewModel used specifically for formatting 
    /// class data for the HomePage's CollectionView bindings.
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