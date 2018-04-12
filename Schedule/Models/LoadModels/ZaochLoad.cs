using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class ZaochLoad
    {
        public Guid Id { get; set; }
        //subject 
        public Subject Subject { get; set; }
        //groups
        public Group Group { get; set; }
        //kind of classes
        public KindOfClasses KindOfClasses { get; set; }
        //form of control
        public FormOfControl FormOfControl { get; set; }
        //teacher
        public TeacherModel Teacher { get; set; }
        //another informstion



        //public string SubjectName { get; set; }
        //public string Faculty { get; set; }
        //public string Caf { get; set; }
        //public string Speciality { get; set; }
        //public int Grade { get; set; }
        public int Term { get; set; }
        //public string Groups { get; set; }
        public int GroupCount { get; set; }
        //public int StudentCount { get; set; }



        //наставная сес
        public int LectionCountFirst { get; set; }
        public int LabCountFirst { get; set; }
        public int PracticeFirst { get; set; }
        public int AllClassesCountFirst { get; set; }


        //зачетная
        public int LabCountSecond { get; set; }
        public int PracticeSecond { get; set; }
        public int AllClassesCountSecond { get; set; }




        public double AllAuditorHours { get; set; }
        public double SelfWorkHours { get; set; }
        public double AllHours { get; set; }
        public double CreditsECTS { get; set; }
        public double BetweenSessionConsult { get; set; }
        public double ConsultBeforeExamOrDiv { get; set; }

        public int RGR { get; set; }
        public int RR { get; set; }
        public int RK { get; set; }


        public CourseWork CourseWork { get; set; }


        public double StudyLoad { get; set; }
        public double Npr { get; set; }
    }
    
}