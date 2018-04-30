using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Classes
{
    public class TableDataDTOZaoch
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

        //наставная сес
        public int? LectionCountFirst { get; set; }        
        public int? LabCountFirst { get; set; }        
        public int? PracticeFirst { get; set; }
        public int? AllClassesCountFirst { get; set; }

        
        //зачетная
        public int? LabCountSecond { get; set; }
        public int? PracticeSecond { get; set; }
        public int? AllClassesCountSecond { get; set; }

        // Всього аудиторних годин 
        //     Самостійна робота 
        //     Всього годин 
        //     Кредити ECTS 
        //     Межсессійна консультація 
        //     Консультаціі перед іспитом та заліком


        public double? AllAuditorHours { get; set; }
        public double? SelfWorkHours { get; set; }
        public double? AllHours { get; set; }
        public double? CreditsECTS { get; set; }
        public double? BetweenSessionConsult { get; set; }
        public double? ConsultBeforeExamOrDiv { get; set; }

        public int? RGR { get; set; }
        public int? RR { get; set; }
        public int? RK { get; set; }
        public int? CourserWork { get; set; }
        public int? CourseProject { get; set; }

        public bool? FormControlZach { get; set; }
        public bool? FormControlDiv { get; set; }
        public bool? FormControlExam { get; set; }

        
        public double StudyLoad { get; set; }
        public double Npr { get; set; }
        public int? Gap { get; set; }
        public string TeachingDepartment { get; set; }
    }
}