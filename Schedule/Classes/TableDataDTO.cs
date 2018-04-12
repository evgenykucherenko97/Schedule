using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Classes
{
    public class TableDataDTODay
    {
        public int id { get; set; }

        public string SubjectName { get; set; }
        public string Faculty { get; set; }
        public string Caf { get; set; }
        public string Speciality { get; set; }
        public int Grade { get; set; }
        public int Term { get; set; }
        public string Groups { get; set; }
        public int GroupCount { get; set; }
        public int StudentCount { get; set; }

        public int? LectionCountAWeekPerFirstHalf { get; set; }
        public int? LectionCountPerFirstHalf { get; set; }
        public int? LabCountAWeekPerFirstHalf { get; set; }
        public int? LabCountPerFirstHalf { get; set; }
        public int? PracticeCountAWeekPerFirstHalf { get; set; }
        public int? PracticeCountPerFirstHalf { get; set; }

        public int? LectionCountAWeekPerSecondHalf { get; set; }
        public int? LectionCountPerSecondHalf { get; set; }
        public int? LabCountAWeekPerSecondHalf { get; set; }
        public int? LabCountPerSecondHalf { get; set; }
        public int? PracticeCountAWeekPerSecondHalf { get; set; }
        public int? PracticeCountPerSecondHalf { get; set; }

        public int? RGR { get; set; }
        public int? RR { get; set; }
        public int? RK { get; set; }
        public int? CourserWork { get; set; }
        public int? CourseProject { get; set; }

        public bool? FormControlZach { get; set; }
        public bool? FormControlDiv { get; set; }
        public bool? FormControlExam { get; set; }

        public double AllCredits { get; set; }
        public double SelfWorkHours { get; set; }
        public double StudyLoad { get; set; }
        public double Npr { get; set; }
    }
}