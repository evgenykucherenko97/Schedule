using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class RegularStudyDayLoadSubjects
    {
        public Guid Id { get; set; }

        //public DayLoadRegular Load { get; set; }
        public Guid? IdLoad { get; set; }
        //subject 
        public Subject Subject { get; set; }
        //groups
        public List<Group> Groups { get; set; }
        public int StudentCount { get; set; }


        //teacher
        public TeacherModel Teacher { get; set; }
        //public Guid TeacherId { get; set; }

        public int Term { get; set; }

        //kind of classes
        public KindOfClasses KindOfClasses { get; set; }
        //kind of classes set two values
        public double? HoursOfWork { get; set; }
        public double? HoursOfWorkAll { get; set; }

        //form of control
        public FormOfControl FormOfControl { get; set; }
        public double? HoursForControl { get; set; }

        //public int? RGR { get; set; }
        //public int? RR { get; set; }
        //public int? RK { get; set; }
        public double? DZ { get; set; }

        public CourseWork CourseWork { get; set; }
        public double? HoursForCourseWork { get; set; }

        public double? Cons { get; set; }

        public double AllCredits { get; set; }
        public double SelfWorkHours { get; set; }
        //public double StudyLoad { get; set; }
        //public double Npr { get; set; }

        public bool IsFRL { get; set; }
    }
}