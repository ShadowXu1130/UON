using System.Globalization;
using UON.Services;

namespace UON.Views;

public partial class HomePage : ContentPage
{
    private readonly TimetableService _timetableService;

    // Note: The hardcoded 'CurrentWeekNumber = 7' has been completely removed 
    // to allow dynamic week calculation based on the current date.

    public HomePage()
    {
        InitializeComponent();
        _timetableService = new TimetableService();

        UpdateUI();
        LoadClasses();
    }

    private void UpdateUI()
    {
        var hour = DateTime.Now.Hour;

        if (hour < 12)
            GreetingLabel.Text = "Good Morning";
        else if (hour < 18)
            GreetingLabel.Text = "Good Afternoon";
        else
            GreetingLabel.Text = "Good Evening";

        var culture = new CultureInfo("en-US");
        DateLabel.Text = $"Today is {DateTime.Now.ToString("dddd, MMM d", culture)}";

        UserEmailLabel.Text = "Xinpeng.Xu@uon.edu.au";

        // Modified: Fetches the remaining classes dynamically without hardcoded parameters
        ClassesCountLabel.Text = _timetableService.GetRemainingClassesThisWeek().ToString();
    }

    private void LoadClasses()
    {
        // Modified: Fetches today's classes dynamically based on the calculated current week
        var todayClasses = _timetableService.GetTodayClasses();

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

    private async void OnSettingsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    public class HomeClassItem
    {
        public string StartTime { get; set; } = "";
        public string EndTime { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string ClassType { get; set; } = "";
        public string AccentColor { get; set; } = "";
    }
}