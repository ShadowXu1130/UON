using System;
using System.Collections.Generic;
using System.Text;

namespace UON.Models;

public class ScheduleItem
{
    public int WeekNumber { get; set; }
    public string Day { get; set; } = "";          // Monday, Tuesday...
    public string CourseCode { get; set; } = "";
    public string CourseName { get; set; } = "";
    public string ClassType { get; set; } = "";    // Lecture / Lab / Workshop
    public string StartTime { get; set; } = "";    // 08:30 AM
    public string EndTime { get; set; } = "";      // 10:30 AM
    public string Lecturer { get; set; } = "";
    public string Location { get; set; } = "";
    public string AccentColor { get; set; } = "";
}