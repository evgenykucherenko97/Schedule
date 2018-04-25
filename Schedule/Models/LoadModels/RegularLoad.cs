using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class RegularStudyDayLoadSubjects
    {
        public Guid Id { get; set; }
        public string LoadName { get; set; }
        //subject 
        public Subject Subject { get; set; }
        //groups
        public List<Group> Groups { get; set; }
        
       
        //teacher
        public TeacherModel Teacher { get; set; }
        //another informstion



        //public string SubjectName { get; set; }

            //group data
        //public string Faculty { get; set; }
        //public string Caf { get; set; }
        //public string Speciality { get; set; }
        //public int Grade { get; set; }
        public int Term { get; set; }
        // now it is propetry Count of listgroups public int GroupCount { get; set; }

        // now we can get it from group list  public int StudentCount { get; set; }



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


        //public int? CourserWork { get; set; }
        //public int? CourseProject { get; set; }
        public CourseWork CourseWork { get; set; }
        public double? HoursForCourseWork { get; set; }

        public double? Cons { get; set; }


        #region
        //GEK hours
        #endregion

        public double AllCredits { get; set; }
        public double SelfWorkHours { get; set; }
        //public double StudyLoad { get; set; }
        //public double Npr { get; set; }

        public bool IsFRL { get; set; }
    }
}