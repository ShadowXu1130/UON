using System.Globalization;
using UON.Services;


namespace UON.Views;

public partial class HomePage : ContentPage
{
    private readonly TimetableService _timetableService;
    private const int CurrentWeekNumber = 7;

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
        ClassesCountLabel.Text = _timetableService.GetRemainingClassesThisWeek(CurrentWeekNumber).ToString();
    }

    private void LoadClasses()
    {
        var todayClasses = _timetableService.GetTodayClasses(CurrentWeekNumber);

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