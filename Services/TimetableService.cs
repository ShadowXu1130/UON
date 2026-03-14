using System;
using System.Collections.Generic;
using System.Text;
using UON.Models;

namespace UON.Services;

public class TimetableService
{
    private readonly List<ScheduleItem> _allSchedules = new()
    {
        // Week 1
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Tuesday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Stem Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "03:00 PM",
            EndTime = "05:00 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Wednesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "09:00 AM",
            EndTime = "11:00 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Stem Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Thursday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Stem Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "12:30 PM",
            EndTime = "02:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Online Learning",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 1,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },

        // Week 2
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "09:00 AM",
            EndTime = "11:00 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Online Learning",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "12:30 PM",
            EndTime = "02:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "09:00 AM",
            EndTime = "11:00 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Online Learning",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "03:30 PM",
            EndTime = "05:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Online Learning",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "01:00 PM",
            EndTime = "03:00 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 2,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },

        // Week 3
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Monday",
            CourseCode = "WS0002",
            CourseName = "UON Special Workshop",
            ClassType = "Workshop",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "N/A",
            Location = "Main Wing",
            AccentColor = "#F3EB00"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Wednesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "12:30 PM",
            EndTime = "02:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "02:30 PM",
            EndTime = "04:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "10:00 AM",
            EndTime = "12:00 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 3,
            Day = "Friday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "03:00 PM",
            EndTime = "05:00 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },

        // Week 4
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Monday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Monday",
            CourseCode = "WS0002",
            CourseName = "UON Special Workshop",
            ClassType = "Workshop",
            StartTime = "03:00 PM",
            EndTime = "05:00 PM",
            Lecturer = "N/A",
            Location = "Online Learning",
            AccentColor = "#F3EB00"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Stem Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "12:00 PM",
            EndTime = "02:00 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "02:30 PM",
            EndTime = "04:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Wednesday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 4,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        
        // Week 6
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Monday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "01:30 PM",
            EndTime = "03:30 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Stem Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Tuesday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Online Learning",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Tuesday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "03:30 PM",
            EndTime = "05:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Online Learning",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "12:00 PM",
            EndTime = "02:00 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Stem Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "12:30 PM",
            EndTime = "02:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 6,
            Day = "Friday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "12:30 PM",
            EndTime = "02:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },

        // Week 7
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Monday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "10:00 AM",
            EndTime = "12:00 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Stem Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Wednesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Thursday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Thursday",
            CourseCode = "RM0000",
            CourseName = "Resume Mastery",
            ClassType = "Workshop",
            StartTime = "03:30 PM",
            EndTime = "05:00 PM",
            Lecturer = "N/A",
            Location = "Main Wing",
            AccentColor = "#F3EB00"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 7,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "01:00 PM",
            EndTime = "03:00 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },

        // Week 8
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Online Learning",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Online Learning",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Wednesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Thursday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Online Learning",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "12:00 PM",
            EndTime = "02:00 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 8,
            Day = "Friday",
            CourseCode = "WS0001",
            CourseName = "Unlocking the Hidden Job Market + LinkedIn",
            ClassType = "Workshop",
            StartTime = "03:30 PM",
            EndTime = "05:00 PM",
            Lecturer = "N/A",
            Location = "Main Wing",
            AccentColor = "#F3EB00"
        },

        // Week 9
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Monday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Stem Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Wednesday",
            CourseCode = "WS0003",
            CourseName = "Interview Mastery",
            ClassType = "Workshop",
            StartTime = "03:30 PM",
            EndTime = "05:00 PM",
            Lecturer = "N/A",
            Location = "Main Wing",
            AccentColor = "#F3EB00"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Main Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 9,
            Day = "Saturday",
            CourseCode = "PH0001",
            CourseName = "Hari Raya Puasa",
            ClassType = "Holiday",
            StartTime = "08:00 AM",
            EndTime = "06:00 PM",
            Lecturer = "N/A",
            Location = "Holiday",
            AccentColor = "#F3EB00"
        },

        // Week 10
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Monday",
            CourseCode = "PH0002",
            CourseName = "PH Off-in lieu",
            ClassType = "Holiday",
            StartTime = "08:00 AM",
            EndTime = "06:00 PM",
            Lecturer = "N/A",
            Location = "Holiday",
            AccentColor = "#F3EB00"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Tuesday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "09:00 AM",
            EndTime = "11:00 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Wednesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 10,
            Day = "Friday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },

        // Week 11
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Monday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "09:30 AM",
            EndTime = "11:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "03:30 PM",
            EndTime = "05:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Online Learning",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Thursday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Thursday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Thursday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 11,
            Day = "Friday",
            CourseCode = "PH0003",
            CourseName = "Good Friday",
            ClassType = "Holiday",
            StartTime = "08:00 AM",
            EndTime = "06:00 PM",
            Lecturer = "N/A",
            Location = "Holiday",
            AccentColor = "#F3EB00"
        },

        // Week 12
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "11:00 AM",
            EndTime = "01:00 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "04:30 PM",
            EndTime = "06:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 12,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },

        // Week 13
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "Human-Computer Interaction",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Dr V Sithira D/O Vadivel",
            Location = "Main Wing",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Tuesday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Tuesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lecture",
            StartTime = "03:30 PM",
            EndTime = "05:30 PM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Main Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Wednesday",
            CourseCode = "SENG2130",
            CourseName = "Systems Analysis and Design",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Adaikkalavan Adaikkalavan",
            Location = "Stem Wing",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "Applied Artificial Intelligence",
            ClassType = "Lab",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Dr Julia Ge",
            Location = "Main Wing",
            AccentColor = "#E6E3B2"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lecture",
            StartTime = "08:30 AM",
            EndTime = "10:30 AM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },
        new ScheduleItem
        {
            WeekNumber = 13,
            Day = "Friday",
            CourseCode = "INFT2051",
            CourseName = "Mobile Application Programming",
            ClassType = "Lab",
            StartTime = "10:30 AM",
            EndTime = "12:30 PM",
            Lecturer = "Low Cheng Hong",
            Location = "Stem Wing",
            AccentColor = "#B7E0B7"
        },

        // Week 14
        new ScheduleItem
        {
            WeekNumber = 14,
            Day = "Monday",
            CourseCode = "SENG2130",
            CourseName = "SENG2130 Exam",
            ClassType = "Exam",
            StartTime = "12:30 PM",
            EndTime = "03:30 PM",
            Lecturer = "N/A",
            Location = "Exam Venue",
            AccentColor = "#B7D3E6"
        },
        new ScheduleItem
        {
            WeekNumber = 14,
            Day = "Thursday",
            CourseCode = "INFT2060",
            CourseName = "INFT2060 Exam",
            ClassType = "Exam",
            StartTime = "12:30 PM",
            EndTime = "03:30 PM",
            Lecturer = "N/A",
            Location = "Exam Venue",
            AccentColor = "#E6E3B2"
        },

        // Week 15
        new ScheduleItem
        {
            WeekNumber = 15,
            Day = "Monday",
            CourseCode = "SENG2260",
            CourseName = "SENG2260 Exam",
            ClassType = "Exam",
            StartTime = "12:30 PM",
            EndTime = "03:30 PM",
            Lecturer = "N/A",
            Location = "Exam Venue",
            AccentColor = "#E0B5E0"
        },
        new ScheduleItem
        {
            WeekNumber = 15,
            Day = "Friday",
            CourseCode = "PH0004",
            CourseName = "Labour Day",
            ClassType = "Holiday",
            StartTime = "08:00 AM",
            EndTime = "06:00 PM",
            Lecturer = "N/A",
            Location = "Holiday",
            AccentColor = "#F3EB00"
        }
    };

    public List<ScheduleItem> GetClassesForWeek(int weekNumber)
    {
        return _allSchedules
            .Where(x => x.WeekNumber == weekNumber)
            .OrderBy(x => GetDayOrder(x.Day))
            .ThenBy(x => DateTime.Parse(x.StartTime))
            .ToList();
    }

    public List<ScheduleItem> GetTodayClasses(int weekNumber)
    {
        string today = DateTime.Now.DayOfWeek switch
        {
            DayOfWeek.Monday => "Monday",
            DayOfWeek.Tuesday => "Tuesday",
            DayOfWeek.Wednesday => "Wednesday",
            DayOfWeek.Thursday => "Thursday",
            DayOfWeek.Friday => "Friday",
            DayOfWeek.Saturday => "Saturday",
            DayOfWeek.Sunday => "Sunday",
            _ => ""
        };

        return _allSchedules
            .Where(x => x.WeekNumber == weekNumber && x.Day == today)
            .OrderBy(x => DateTime.Parse(x.StartTime))
            .ToList();
    }

    public int GetRemainingClassesThisWeek(int weekNumber)
    {
        string today = DateTime.Now.DayOfWeek switch
        {
            DayOfWeek.Monday => "Monday",
            DayOfWeek.Tuesday => "Tuesday",
            DayOfWeek.Wednesday => "Wednesday",
            DayOfWeek.Thursday => "Thursday",
            DayOfWeek.Friday => "Friday",
            DayOfWeek.Saturday => "Saturday",
            DayOfWeek.Sunday => "Sunday",
            _ => ""
        };

        int todayOrder = GetDayOrder(today);

        return _allSchedules.Count(x =>
            x.WeekNumber == weekNumber &&
            GetDayOrder(x.Day) >= todayOrder);
    }

    private int GetDayOrder(string day)
    {
        return day switch
        {
            "Monday" => 1,
            "Tuesday" => 2,
            "Wednesday" => 3,
            "Thursday" => 4,
            "Friday" => 5,
            "Saturday" => 6,
            "Sunday" => 7,
            _ => 99
        };
    }
}
