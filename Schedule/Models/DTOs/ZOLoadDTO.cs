using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class ZOLoadDTO
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public int Grade { get; set; }
        public int GroupCount { get; set; }
        public int StudentCount { get; set; }
        public int Term { get; set; }

        //наставная сес
        public string DateFirst { get; set; }
        public int? LectionCountFirst { get; set; }
        public int? PracticeLabCountFirst { get; set; }
        public int? PracticeLabCountFirstAll { get; set; }

        public double? DZ { get; set; }
        public double BetweenSessionConsult { get; set; }

        //зачетная
        public string DateSecond { get; set; }
        public int? LectionCountSecond { get; set; }
        public int? PracticeCountSecond { get; set; }
        public int? PracticeCountSecondAll { get; set; }
        public int? LabCountSecond { get; set; }
        public int? LabCountSecondAll { get; set; }

        public double? HoursForCourseWork { get; set; }

        public double? Cons { get; set; }
        public double? ConsAll { get; set; }

        public double? ExamHours { get; set; }
        public double? DivHours { get; set; }

        public double? AllHours { get; set; }

        public string TeacherName { get; set; }

        public string PartOfYear { get; set; }
        public double Npr { get; set; }
        public double CreditsECTS { get; set; }
        public double? SelfWorkHours { get; set; }        
    }
}