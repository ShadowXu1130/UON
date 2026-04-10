using Microsoft.Maui.Controls.Shapes;
using System.Globalization;
using UON.Models;
using UON.Services;

namespace UON.Views;

/// <summary>
/// Code-behind for the Timetable Page.
/// This class handles dynamic UI generation, grid-based layout calculations, 
/// and automated academic week detection to ensure a data-driven user experience.
/// </summary>
public partial class TimetablePage : ContentPage
{
    // Stores the dynamically calculated list of academic weeks and their specific start dates.
    private readonly List<(string WeekName, DateTime StartDate)> _weeks = new();

    // Dependency injection for the service layer that provides schedule data.
    private readonly TimetableService _timetableService = new();

    // Tracks the currently selected week index (0-based).
    private int _currentWeekIndex;

    /// <summary>
    /// Initializes the TimetablePage and bootstraps the initial schedule state.
    /// </summary>
    public TimetablePage()
    {
        InitializeComponent();

        // 1. Generate the academic calendar for the semester.
        SetupWeeks();

        // 2. Automatically determine which week to display based on the current system date.
        _currentWeekIndex = CalculateInitialWeekIndex();

        // 3. Synchronize the UI Picker and render the grid.
        SetupPicker();
        UpdateWeekDisplay();
    }

    /// <summary>
    /// Populates the semester schedule with 15 weeks starting from a fixed academic date.
    /// </summary>
    private void SetupWeeks()
    {
        // Define the official start date of Semester 1 (Monday, Jan 19, 2026).
        var week1Start = new DateTime(2026, 1, 19);

        // Generate a sequence of 15 academic weeks.
        for (int i = 1; i <= 15; i++)
        {
            _weeks.Add(($"Week {i}", week1Start.AddDays((i - 1) * 7)));
        }
    }

    /// <summary>
    /// Dynamically calculates the index of the current week based on "Today's" date.
    /// This eliminates hardcoded week selections (e.g., Week 7).
    /// </summary>
    /// <returns>The index of the week matching the current date.</returns>
    private int CalculateInitialWeekIndex()
    {
        var today = DateTime.Today;

        for (int i = 0; i < _weeks.Count; i++)
        {
            var weekStart = _weeks[i].StartDate;
            var weekEnd = weekStart.AddDays(7); // Define the end of the 7-day window.

            // If today falls within this week's range, return this index.
            if (today >= weekStart && today < weekEnd)
            {
                return i;
            }
        }

        // Boundary Protection: If today is before the semester, show Week 1.
        if (today < _weeks[0].StartDate) return 0;

        // Boundary Protection: If today is after the semester, show the final week.
        return _weeks.Count - 1;
    }

    /// <summary>
    /// Binds the generated academic week names to the UI Picker (Dropdown).
    /// </summary>
    private void SetupPicker()
    {
        WeekPicker.ItemsSource = _weeks.Select(w => w.WeekName).ToList();
        WeekPicker.SelectedIndex = _currentWeekIndex;
    }

    /// <summary>
    /// FIX: Handles the tap event on the Week selector border.
    /// Programmatically triggers the Picker focus to resolve UI hit-testing/interaction issues.
    /// </summary>
    private void OnWeekDisplayTapped(object sender, EventArgs e)
    {
        // Forces the hidden Picker to open, ensuring the center of the text is clickable.
        WeekPicker.Focus();
    }

    /// <summary>
    /// Orchestrates the UI refresh process when the selected week changes.
    /// Updates labels, day headers, and re-renders the schedule grid.
    /// </summary>
    private void UpdateWeekDisplay()
    {
        if (_currentWeekIndex < 0 || _currentWeekIndex >= _weeks.Count)
            return;

        var selectedWeek = _weeks[_currentWeekIndex];
        var start = selectedWeek.StartDate;
        var end = start.AddDays(6);

        var culture = new CultureInfo("en-US");

        // Update UI Text elements with dynamic week information.
        WeekDisplayLabel.Text = selectedWeek.WeekName;
        WeekRangeLabel.Text = $"{start.ToString("MMM d", culture)} - {end.ToString("MMM d", culture)}";

        // Refresh headers and timetable blocks.
        UpdateDayHeaders(start);
        RenderScheduleBlocks(_currentWeekIndex + 1);
    }

    /// <summary>
    /// Updates the top row of the timetable grid with specific dates for the current week.
    /// </summary>
    private void UpdateDayHeaders(DateTime weekStart)
    {
        var culture = new CultureInfo("en-US");

        Day1Label.Text = $"{weekStart.ToString("ddd", culture).ToUpper()}\n{weekStart.ToString("MMM d", culture)}";
        Day2Label.Text = $"{weekStart.AddDays(1).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(1).ToString("MMM d", culture)}";
        Day3Label.Text = $"{weekStart.AddDays(2).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(2).ToString("MMM d", culture)}";
        Day4Label.Text = $"{weekStart.AddDays(3).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(3).ToString("MMM d", culture)}";
        Day5Label.Text = $"{weekStart.AddDays(4).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(4).ToString("MMM d", culture)}";
        Day6Label.Text = $"{weekStart.AddDays(5).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(5).ToString("MMM d", culture)}";
        Day7Label.Text = $"{weekStart.AddDays(6).ToString("ddd", culture).ToUpper()}\n{weekStart.AddDays(6).ToString("MMM d", culture)}";
    }

    /// <summary>
    /// Clears previous class blocks and dynamically renders new ones onto the Grid coordinate system.
    /// </summary>
    private void RenderScheduleBlocks(int weekNumber)
    {
        // Identify static UI elements (Day/Time labels) that must be preserved.
        var fixedViews = new HashSet<View>
        {
            Day1Label, Day2Label, Day3Label, Day4Label, Day5Label, Day6Label, Day7Label
        };

        // Filter and remove only the dynamic class cards (Borders) to prevent UI stacking.
        var removable = TimetableGrid.Children
            .Where(v =>
            {
                if (fixedViews.Contains(v)) return false;
                if (v is Label lbl && Grid.GetColumn(lbl) == 0) return false;
                if (v is BoxView) return false;
                return true;
            })
            .ToList();

        foreach (var child in removable)
            TimetableGrid.Children.Remove(child);

        // Fetch data for the selected week and map them to Grid coordinates.
        var weekClasses = _timetableService.GetClassesForWeek(weekNumber);

        foreach (var item in weekClasses)
        {
            var border = CreateScheduleBlock(item);

            Grid.SetColumn(border, GetDayColumn(item.Day));
            Grid.SetRow(border, GetStartRow(item.StartTime));
            Grid.SetRowSpan(border, GetRowSpan(item.StartTime, item.EndTime));

            TimetableGrid.Children.Add(border);
        }
    }

    /// <summary>
    /// Programmatically constructs a visual Card (Border) representing a specific class.
    /// </summary>
    private Border CreateScheduleBlock(ScheduleItem item)
    {
        // Determine the text color for the class type label based on category.
        var typeLabelColor = item.ClassType switch
        {
            "Lecture" => "#245C82",
            "Lab" => "#2E7D32",
            "Workshop" => "#8C6B00",
            "Exam" => "#C62828",
            _ => "#333333"
        };

        // Override colors for specific major courses to enhance UI scannability.
        if (item.CourseCode == "INFT2060") typeLabelColor = "#8C7B00";
        else if (item.CourseCode == "SENG2130") typeLabelColor = "#245C82";

        return new Border
        {
            BackgroundColor = Color.FromArgb(item.AccentColor),
            Margin = new Thickness(2),
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) },
            Content = new VerticalStackLayout
            {
                Padding = 8,
                Spacing = 2,
                Children =
                {
                    new Label { Text = item.CourseCode, TextColor = Colors.Black, FontSize = 11, FontAttributes = FontAttributes.Bold, LineBreakMode = LineBreakMode.TailTruncation },
                    new Label { Text = item.CourseName, TextColor = Colors.Black, FontSize = 10, LineBreakMode = LineBreakMode.WordWrap, MaxLines = 2 },
                    new Label { Text = item.ClassType, TextColor = Color.FromArgb(typeLabelColor), FontSize = 9, FontAttributes = FontAttributes.Bold },
                    new Label { Text = $"{FormatTimeRange(item.StartTime, item.EndTime)}", TextColor = Colors.Black, FontSize = 9 }
                }
            }
        };
    }

    // --- Helper Methods for Grid Calculations ---

    private int GetDayColumn(string day) => day switch
    {
        "Monday" => 1,
        "Tuesday" => 2,
        "Wednesday" => 3,
        "Thursday" => 4,
        "Friday" => 5,
        "Saturday" => 6,
        "Sunday" => 7,
        _ => 1
    };

    private int GetStartRow(string startTime)
    {
        var time = DateTime.Parse(startTime);
        var baseTime = DateTime.Today.AddHours(8); // Grid starts at 08:00 AM.
        var minutesFromStart = (int)(time - baseTime).TotalMinutes;
        return 1 + (minutesFromStart / 30); // 30-minute row intervals.
    }

    private int GetRowSpan(string startTime, string endTime)
    {
        var durationMinutes = (int)(DateTime.Parse(endTime) - DateTime.Parse(startTime)).TotalMinutes;
        return Math.Max(1, durationMinutes / 30);
    }

    private string FormatTimeRange(string startTime, string endTime)
    {
        return $"{DateTime.Parse(startTime):hh:mm} - {DateTime.Parse(endTime):hh:mm}";
    }

    // --- Navigation Event Handlers ---

    private void OnPreviousWeekTapped(object sender, TappedEventArgs e)
    {
        if (_currentWeekIndex > 0)
        {
            _currentWeekIndex--;
            WeekPicker.SelectedIndex = _currentWeekIndex;
            UpdateWeekDisplay();
        }
    }

    private void OnNextWeekTapped(object sender, TappedEventArgs e)
    {
        if (_currentWeekIndex < _weeks.Count - 1)
        {
            _currentWeekIndex++;
            WeekPicker.SelectedIndex = _currentWeekIndex;
            UpdateWeekDisplay();
        }
    }

    private void OnWeekChanged(object sender, EventArgs e)
    {
        if (WeekPicker.SelectedIndex >= 0)
        {
            _currentWeekIndex = WeekPicker.SelectedIndex;
            UpdateWeekDisplay();
        }
    }
}