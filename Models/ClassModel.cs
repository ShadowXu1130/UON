using System;
using System.Collections.Generic;
using System.Text;

namespace UON.Models;

public class ClassModel
{
    public required string CourseCode { get; set; }
    public required string CourseName { get; set; }
    public required string Time { get; set; }
    public required string Location { get; set; }
    public required string Lecturer { get; set; }
    public DayOfWeek Day { get; set; }
}


