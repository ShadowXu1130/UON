using Microsoft.Maui.Controls.Shapes;
using System.Globalization;
using UON.Models;
using UON.Services;


namespace UON.Views;

public partial class TimetablePage : ContentPage
{
    private readonly List<(string WeekName, DateTime StartDate)> _weeks = new();
    private readonly TimetableService _timetableService = new();
    private int _currentWeekIndex = 6; // Week 7

    public TimetablePage()
    {
        InitializeComponent();
        SetupWeeks();
        SetupPicker();
        UpdateWeekDisplay();
    }

    private void SetupWeeks()
    {
        var week1Start = new DateTime(2026, 1, 19);

        for (int i = 1; i <= 15; i++)
        {
            _weeks.Add(($"Week {i}", week1Start.AddDays((i - 1) * 7)));
        }
    }

    private void SetupPicker()
    {
        WeekPicker.ItemsSource = _weeks.Select(w => w.WeekName).ToList();
        WeekPicker.SelectedIndex = _currentWeekIndex;
    }

    private void UpdateWeekDisplay()
    {
        if (_currentWeekIndex < 0 || _currentWeekIndex >= _weeks.Count)
            return;

        var selectedWeek = _weeks[_currentWeekIndex];
        var start = selectedWeek.StartDate;
        var end = start.AddDays(6);

        var culture = new CultureInfo("en-US");

        WeekDisplayLabel.Text = selectedWeek.WeekName;
        WeekRangeLabel.Text = $"{start.ToString("MMM d", culture)} - {end.ToString("MMM d", culture)}";

        UpdateDayHeaders(start);
        RenderScheduleBlocks(_currentWeekIndex + 1);
    }

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

    private void RenderScheduleBlocks(int weekNumber)
    {
        var fixedViews = new HashSet<View>
        {
            Day1Label, Day2Label, Day3Label, Day4Label, Day5Label, Day6Label, Day7Label
        };

        var removable = TimetableGrid.Children
            .Where(v =>
            {
                if (fixedViews.Contains(v))
                    return false;

                if (v is Label lbl)
                {
                    var col = Grid.GetColumn(lbl);
                    if (col == 0)
                        return false; // 左侧时间标签
                }

                if (v is BoxView)
                    return false; // 背景

                return true;
            })
            .ToList();

        foreach (var child in removable)
            TimetableGrid.Children.Remove(child);

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

    private Border CreateScheduleBlock(ScheduleItem item)
    {
        var typeColor = item.ClassType switch
        {
            "Lecture" => "#245C82",
            "Lab" => "#2E7D32",
            "Workshop" => "#8C6B00",
            "Holiday" => "#8C6B00",
            "Exam" => "#C62828",
            _ => "#333333"
        };

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
        var baseTime = DateTime.Today.AddHours(8); // 08:00 起点

        var minutesFromStart = (int)(time - baseTime).TotalMinutes;
        var halfHourSlots = minutesFromStart / 30;

        return 1 + halfHourSlots;
    }

    private int GetRowSpan(string startTime, string endTime)
    {
        var start = DateTime.Parse(startTime);
        var end = DateTime.Parse(endTime);

        var durationMinutes = (int)(end - start).TotalMinutes;
        return Math.Max(1, durationMinutes / 30);
    }

    private string FormatTimeRange(string startTime, string endTime)
    {
        var start = DateTime.Parse(startTime).ToString("hh:mm");
        var end = DateTime.Parse(endTime).ToString("hh:mm");
        return $"{start} - {end}";
    }

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