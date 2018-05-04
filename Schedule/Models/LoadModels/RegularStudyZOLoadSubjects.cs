using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class RegularStudyZOLoadSubjects
    {
        public Guid Id { get; set; }
        
        public Guid? LoadId { get; set; }
        //subject 
        public Subject Subject { get; set; }
        //groups
        public virtual ICollection<Group> Groups { get; set; }
        public RegularStudyZOLoadSubjects()
        {
            Id = Guid.NewGuid();
            Groups = new List<Group>();
        }
        public int? StudentCount { get; set; }
        public void setStudentCount()
        {
            StudentCount = 0;
            foreach(var group in Groups)
            {
                StudentCount += group.StudentCount;
            }
        }
        //teacher
        public TeacherModel Teacher { get; set; }

        public int Term { get; set; }

        //наставная сес
        public string DateFirst { get; set; }
        public int? LectionCountFirst { get; set; }        
        public int? PracticeLabCountFirst { get; set; }
        public int? PracticeLabCountFirstAll { get; set; }

        //public int? RGR { get; set; }
        //public int? RR { get; set; }
        //public int? RK { get; set; }
        public double? DZ { get; set; }
        public void setDZ()
        {
            if (StudentCount != null || StudentCount != 0)
            {
                DZ = StudentCount / 2.0;
            }
        }

        public double BetweenSessionConsult { get; set; }

        //зачетная
        public string DateSecond { get; set; }
        public int? LectionCountSecond { get; set; }
        public int? PracticeCountSecond { get; set; }
        public int? PracticeCountSecondAll { get; set; }
        public int? LabCountSecond { get; set; }
        public int? LabCountSecondAll { get; set; }

        public CourseWork CourseWork { get; set; }
        public double? HoursForCourseWork { get; set; }
        public void setHoursForCourseWork()
        {
            if (CourseWork == CourseWork.CourseProject)
            {
                HoursForCourseWork = StudentCount * 4;
            }
            else if (CourseWork == CourseWork.CourseWork)
            {
                HoursForCourseWork = StudentCount * 3;
            }
            else
            {
                HoursForCourseWork = null;
            }
        }

        //public double ConsultBeforeExamOrDiv { get; set; }
        public double? Cons { get; set; }
        public double? ConsAll { get; set; }

        //form of control
        public FormOfControl FormOfControl { get; set; }
        public double? HoursForControl { get; set; }
        public void setHoursForControl()
        {
            if (FormOfControl == FormOfControl.FormControlDiv || FormOfControl == FormOfControl.FormControlZach)
            {
                HoursForControl = 2;
            }
            else if (FormOfControl == FormOfControl.FormControlExam)
            {
                HoursForControl = StudentCount / 3.0303;
            }
            else HoursForControl = 0;
        }
        
        public double? SelfWorkHours { get; set; }
        public double? AllHours { get; set; }
        public double CreditsECTS { get; set; }
        public double Npr { get; set; }
        public string PartOfYear { get; set; }
        public void setPartOfYear()
        {
            if ((double)Term % 2 == 0)
            {
                PartOfYear = "Весна";
            }
            else
            {
                PartOfYear = "Осень";
            }
        }
    }
}