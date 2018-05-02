using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class DayLoadDTO
    {
        public Guid Id { get; set; }
        public Guid? LoadId { get; set; }

        public string SubjectName { get; set; }
        public int Grade { get; set; }
        public int GroupCount { get; set; }
        public int StudentCount { get; set; }
        public int Term { get; set; }

        public double? DZ { get; set; }
        public double? HoursOfLections { get; set; }
        public double? HoursOfLabWork { get; set; }
        public double? HoursOfLabWorkAll { get; set; }
        public double? HoursOfPractWork { get; set; }
        public double? HoursOfPractWorkAll { get; set; }

        public double? KP_KR { get; set; }
        public double? Cons { get; set; }

        public double? ExamHours { get; set; }
        public double? DivHours { get; set; }

        public double? GraduatingBaschelorWork { get; set; }
        public double? DP { get; set; }
        public double? ProizvPractice { get; set; }
        public double? PreDiplomPractice { get; set; }
        public double? Magistr { get; set; }
        public double? Aspir { get; set; }
        public double? GEK { get; set; }
        public double? SelfWork { get; set; }
        public double? AllHours { get; set; }

        public string TeacherName { get; set; }
    }
}