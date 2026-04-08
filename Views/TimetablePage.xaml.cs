using Microsoft.Maui.Controls.Shapes;
using System.Globalization;
using UON.Models;
using UON.Services;

namespace UON.Views;

/// <summary>
/// The code-behind for the Timetable Page.
/// Handles dynamic UI generation, grid-based layout calculations, and week-by-week schedule navigation.
/// </summary>
public partial class TimetablePage : ContentPage
{
    // Stores the dynamically calculated list of academic weeks and their starting dates.
    private readonly List<(string WeekName, DateTime StartDate)> _weeks = new();

    // Service layer dependency for fetching schedule data.
    private readonly TimetableService _timetableService = new();

    // Tracks the currently selected week (Zero-based index. 6 equals Week 7).
    private int _currentWeekIndex = 6; // Week 7

    /// <summary>
    /// Initializes the Timetable view and bootstraps the initial schedule display.
    /// </summary>
    public TimetablePage()
    {
        InitializeComponent();
        SetupWeeks();
        SetupPicker();
        UpdateWeekDisplay();
    }

    /// <summary>
    /// Populates the semester schedule starting from a fixed academic calendar date.
    /// </summary>
    private void SetupWeeks()
    {
        // Base start date for Semester 1
        var week1Start = new DateTime(2026, 1, 19);

        // Generate 15 consecutive academic weeks
        for (int i = 1; i <= 15; i++)
        {
            _weeks.Add(($"Week {i}", week1Start.AddDays((i - 1) * 7)));
        }
    }

    /// <summary>
    /// Binds the generated week data to the UI dropdown picker.
    /// </summary>
    private void SetupPicker()
    {
        WeekPicker.ItemsSource = _weeks.Select(w => w.WeekName).ToList();
        WeekPicker.SelectedIndex = _currentWeekIndex;
    }

    /// <summary>
    /// Orchestrates the UI refresh process when a user navigates to a different week.
    /// </summary>
    private void UpdateWeekDisplay()
    {
        if (_currentWeekIndex < 0 || _currentWeekIndex >= _weeks.Count)
            return;

        var selectedWeek = _weeks[_currentWeekIndex];
        var start = selectedWeek.StartDate;
        var end = start.AddDays(6);

        var culture = new CultureInfo("en-US");

        // Update the header titles with the specific date range for the selected week
        WeekDisplayLabel.Text = selectedWeek.WeekName;
        WeekRangeLabel.Text = $"{start.ToString("MMM d", culture)} - {end.ToString("MMM d", culture)}";

        // Refresh the underlying grid headers and schedule blocks
        UpdateDayHeaders(start);
        RenderScheduleBlocks(_currentWeekIndex + 1);
    }

    /// <summary>
    /// Updates the top row of the timetable grid with specific dates for Monday to Sunday.
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
    /// Dynamically clears previous schedule blocks and renders new ones onto the Grid.
    /// </summary>
    private void RenderScheduleBlocks(int weekNumber)
    {
        // 1. Define the static UI elements that should NOT be removed
        var fixedViews = new HashSet<View>
        {
            Day1Label, Day2Label, Day3Label, Day4Label, Day5Label, Day6Label, Day7Label
        };

        // 2. Identify dynamically generated blocks from previous renders
        var removable = TimetableGrid.Children
            .Where(v =>
            {
                if (fixedViews.Contains(v))
                    return false;

                if (v is Label lbl)
                {
                    var col = Grid.GetColumn(lbl);
                    if (col == 0)
                        return false; // Preserve the left-side time axis labels
                }

                if (v is BoxView)
                    return false; // Preserve background grid lines

                return true; // Mark old class blocks for deletion
            })
            .ToList();

        // 3. Clean up the grid to prevent UI stacking/memory leaks
        foreach (var child in removable)
            TimetableGrid.Children.Remove(child);

        // 4. Fetch new data and draw blocks at specific Grid coordinates
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
    /// Programmatically constructs a visual Card (Border) for a specific class instance.
    /// </summary>
    private Border CreateScheduleBlock(ScheduleItem item)
    {
        // Assign semantic colors based on class type
        var typeColor = item.ClassType switch
        {
            "Lecture" => "#245C82",
            "Lab" => "#2E7D32",
            "Workshop" => "#8C6B00",
            "Holiday" => "#8C6B00",
            "Exam" => "#C62828",
            _ => "#333333"
        };

        // Override colors for specific prominent courses
        if (item.CourseCode == "INFT2060")
            typeColor = "#8C7B00";
        else if (item.CourseCode == "SENG2130")
            typeColor = "#245C82";
        else if (item.CourseCode == "INFT2051")
            typeColor = "#2E7D32";
        else if (item.CourseCode == "SENG2260")
            typeColor = "#8E3A8E";
        else if (item.ClassType == "Workshop")
            typeColor = "#8C6B00";

        if (item.ClassType == "Holiday")
            typeColor = "#8C6B00";
        else if (item.ClassType == "Exam")
            typeColor = "#C62828";

        // Construct the visual hierarchy
        return new Border
        {
            BackgroundColor = Color.FromArgb(item.AccentColor),
            Margin = new Thickness(2),
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10)
            },
            Content = new VerticalStackLayout
            {
                Padding = 8,
                Spacing = 2,
                Children =
                {
                    new Label
                    {
                        Text = item.CourseCode,
                        TextColor = Colors.Black,
                        FontSize = 11,
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.TailTruncation
                    },
                    new Label
                    {
                        Text = item.CourseName,
                        TextColor = Colors.Black,
                        FontSize = 10,
                        LineBreakMode = LineBreakMode.WordWrap,
                        MaxLines = 2
                    },
                    new Label
                    {
                        Text = item.ClassType,
                        TextColor = Color.FromArgb(typeColor),
                        FontSize = 9,
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label
                    {
                        Text = $"{FormatTimeRange(item.StartTime, item.EndTime)}",
                        TextColor = Colors.Black,
                        FontSize = 9
                    }
                }
            }
        };
    }

    /// <summary>
    /// Maps a string day representation to the corresponding Grid column index.
    /// </summary>
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

    /// <summary>
    /// Calculates the starting Grid Row based on the class start time.
    /// Utilizes a 30-minute interval grid system starting at 08:00 AM.
    /// </summary>
    private int GetStartRow(string startTime)
    {
        var time = DateTime.Parse(startTime);
        var baseTime = DateTime.Today.AddHours(8); // 08:00 AM Start Point

        var minutesFromStart = (int)(time - baseTime).TotalMinutes;
        var halfHourSlots = minutesFromStart / 30;

        return 1 + halfHourSlots;
    }

    /// <summary>
    /// Calculates how many Grid Rows a class block should span based on its duration.
    /// </summary>
    private int GetRowSpan(string startTime, string endTime)
    {
        var start = DateTime.Parse(startTime);
        var end = DateTime.Parse(endTime);

        var durationMinutes = (int)(end - start).TotalMinutes;
        return Math.Max(1, durationMinutes / 30);
    }

    /// <summary>
    /// Formats the start and end times into a clean display string.
    /// </summary>
    private string FormatTimeRange(string startTime, string endTime)
    {
        var start = DateTime.Parse(startTime).ToString("hh:mm");
        var end = DateTime.Parse(endTime).ToString("hh:mm");
        return $"{start} - {end}";
    }

    /// <summary>
    /// Event handler for the previous week navigation button.
    /// </summary>
    private void OnPreviousWeekTapped(object sender, TappedEventArgs e)
    {
        if (_currentWeekIndex > 0)
        {
            _currentWeekIndex--;
            WeekPicker.SelectedIndex = _currentWeekIndex;
            UpdateWeekDisplay();
        }
    }

    /// <summary>
    /// Event handler for the next week navigation button.
    /// </summary>
    private void OnNextWeekTapped(object sender, TappedEventArgs e)
    {
        if (_currentWeekIndex < _weeks.Count - 1)
        {
            _currentWeekIndex++;
            WeekPicker.SelectedIndex = _currentWeekIndex;
            UpdateWeekDisplay();
        }
    }

    /// <summary>
    /// Event handler triggered when the user selects a week from the dropdown picker.
    /// </summary>
    private void OnWeekChanged(object sender, EventArgs e)
    {
        if (WeekPicker.SelectedIndex >= 0)
        {
            _currentWeekIndex = WeekPicker.SelectedIndex;
            UpdateWeekDisplay();
        }
    }
}