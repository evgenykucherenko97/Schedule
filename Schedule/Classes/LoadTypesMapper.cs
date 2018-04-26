using Schedule.Models.DTOs;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Classes
{
    public static class LoadTypesMapper
    {
        public static DayLoadDTO DayLoadDTO(RegularStudyDayLoadSubjects load)
        {
            DayLoadDTO loadDTO = new DayLoadDTO();
            loadDTO.Id = load.Id;
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.StudentCount = load.StudentCount;
            loadDTO.GroupCount = load.Groups.Count;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.Term = load.Term;
            loadDTO.Cons = load.Cons;
            loadDTO.DZ = load.DZ;
            loadDTO.SelfWork = load.SelfWorkHours;
            loadDTO.AllHours = load.AllCredits;
            if (load.FormOfControl == FormOfControl.FormControlDiv || load.FormOfControl == FormOfControl.FormControlZach)
            {
                loadDTO.DivHours = load.HoursForControl;
                loadDTO.ExamHours = null;
            }
            else if (load.FormOfControl == FormOfControl.FormControlExam)
            {
                loadDTO.ExamHours = load.HoursForControl;
                loadDTO.DivHours = null;
            }
            else
            {
                loadDTO.ExamHours = null;
                loadDTO.DivHours = null;
            }
            loadDTO.GraduatingBaschelorWork = null;
            loadDTO.DP = null;
            loadDTO.ProizvPractice = null;
            loadDTO.PreDiplomPractice = null;
            loadDTO.Magistr = null;
            loadDTO.Aspir = null;
            loadDTO.GEK = null;
            loadDTO.TeacherName = "teacher Name";
            loadDTO.KP_KR = load.HoursForCourseWork;
            if (load.KindOfClasses == KindOfClasses.Labs)
            {
                loadDTO.HoursOfLections = null;
                loadDTO.HoursOfLabWork = load.HoursOfWork;
                loadDTO.HoursOfLabWorkAll = load.HoursOfWorkAll;
                loadDTO.HoursOfPractWork = null;
                loadDTO.HoursOfPractWorkAll = null;
            }        
            if (load.KindOfClasses == KindOfClasses.Lections)
            {
                loadDTO.HoursOfLections = load.HoursOfWork;
                loadDTO.HoursOfLabWork = null;
                loadDTO.HoursOfLabWorkAll = null;
                loadDTO.HoursOfPractWork = null;
                loadDTO.HoursOfPractWorkAll = null;
            }
            if (load.KindOfClasses == KindOfClasses.Prsctices)
            {
                loadDTO.HoursOfLections = null;
                loadDTO.HoursOfLabWork = null;
                loadDTO.HoursOfLabWorkAll = null;
                loadDTO.HoursOfPractWork = load.HoursOfWork;
                loadDTO.HoursOfPractWorkAll = load.HoursOfWorkAll;
            }
            return loadDTO;
        }

        public static DayLoadDTO DayLoadDTO(RegularStudyDayLoadGEK load)
        {
            DayLoadDTO loadDTO = new DayLoadDTO();
            loadDTO.Id = load.Id;
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.StudentCount = load.StudentCount;
            loadDTO.GroupCount = load.Groups.Count;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.Term = load.Term;
            loadDTO.Cons = load.Cons;
            loadDTO.DZ = null;
            
            loadDTO.SelfWork = null;
            loadDTO.AllHours = load.AllCredits;     
            loadDTO.ExamHours = null;
            loadDTO.DivHours = null;      

            loadDTO.GraduatingBaschelorWork = load.GraduatingBaschelorWork;
            loadDTO.DP = load.DP;
            loadDTO.ProizvPractice = load.ProizvPractice;
            loadDTO.PreDiplomPractice = load.PreDiplomPractice;
            loadDTO.Magistr = load.Magistr;
            loadDTO.Aspir = load.Aspir;
            loadDTO.GEK = load.GEK;

            loadDTO.TeacherName = "teacher Name";
            loadDTO.KP_KR = null;            
            loadDTO.HoursOfLections = null;
            loadDTO.HoursOfLabWork = null;
            loadDTO.HoursOfLabWorkAll = null;
            loadDTO.HoursOfPractWork = null;
            loadDTO.HoursOfPractWorkAll = null;            
            return loadDTO;
        }
    }
}
