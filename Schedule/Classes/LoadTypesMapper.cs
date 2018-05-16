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
            if (load.Teacher != null)
            {
                loadDTO.TeacherName = load.Teacher.ToString();
                loadDTO.TeacherId = load.Teacher.Id;
            }
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.StudentCount = load.StudentCount;
            loadDTO.GroupCount = load.Groups.Count;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.Term = load.Term;
            loadDTO.Cons = load.Cons;
            loadDTO.DZ = load.DZ;
            loadDTO.SelfWork = load.SelfWorkHours;
            loadDTO.AllHours = load.AllCredits;

            loadDTO.ExamHours = null;
            loadDTO.DivHours = null;
            if (load.FormOfControl == FormOfControl.FormControlDiv || load.FormOfControl == FormOfControl.FormControlZach)
            {
                loadDTO.DivHours = load.HoursForControl;
            }
            else if (load.FormOfControl == FormOfControl.FormControlExam)
            {
                loadDTO.ExamHours = load.HoursForControl;
            }
            //loadDTO.GraduatingBaschelorWork = null;
            //loadDTO.DP = null;
            //loadDTO.ProizvPractice = null;
            //loadDTO.PreDP = null;
            //loadDTO.Magistr = null;
            //loadDTO.Aspir = null;
            //loadDTO.GEK = null;
            loadDTO.KP_KR = load.HoursForCourseWork;
            if (load.KindOfClasses == KindOfClasses.Labs)
            {
                //loadDTO.HoursOfLections = null;
                loadDTO.HoursOfLabWork = load.HoursOfWork;
                loadDTO.HoursOfLabWorkAll = load.HoursOfWorkAll;
                //loadDTO.HoursOfPractWork = null;
                //loadDTO.HoursOfPractWorkAll = null;
            }
            if (load.KindOfClasses == KindOfClasses.Lections)
            {
                loadDTO.HoursOfLections = load.HoursOfWork;
                //loadDTO.HoursOfLabWork = null;
                //loadDTO.HoursOfLabWorkAll = null;
                //loadDTO.HoursOfPractWork = null;
                //loadDTO.HoursOfPractWorkAll = null;
            }
            if (load.KindOfClasses == KindOfClasses.Prsctices)
            {
                //loadDTO.HoursOfLections = null;
                //loadDTO.HoursOfLabWork = null;
                //loadDTO.HoursOfLabWorkAll = null;
                loadDTO.HoursOfPractWork = load.HoursOfWork;
                loadDTO.HoursOfPractWorkAll = load.HoursOfWorkAll;
            }
            return loadDTO;
        }

        public static DayLoadDTO DayLoadDTO(RegularStudyDayLoadGEK load)
        {
            DayLoadDTO loadDTO = new DayLoadDTO();
            loadDTO.Id = load.Id;
            if (load.Teacher != null)
            {
                loadDTO.TeacherName = load.Teacher.ToString();
                loadDTO.TeacherId = load.Teacher.Id;
            }
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.StudentCount = load.StudentCount;
            loadDTO.GroupCount = load.GroupCount;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.Term = load.Term;
            //loadDTO.Cons = null;// load.Cons;
            //loadDTO.DZ = null;

            //loadDTO.SelfWork = null;
            loadDTO.AllHours = load.AllCredits;
            //loadDTO.ExamHours = null;
            //loadDTO.DivHours = null;

            //loadDTO.GraduatingBaschelorWork = null;// load.GraduatingBaschelorWork;
            //loadDTO.DP = null;// load.DP;
            //loadDTO.ProizvPractice = null;// load.ProizvPractice;
            //loadDTO.PreDP = null;// load.PreDiplomPractice;
            //loadDTO.Magistr = null;// load.Magistr;
            //loadDTO.Aspir = null;///////////////////////////// load.Aspir;
            //loadDTO.GEK = null;// load.GEK;

            loadDTO.AllHours = 0;

            switch (load.GEK_Work)
            {
                case GEK_Work.GEK4:
                    {
                        loadDTO.GEK = load.HoursForWork;
                        break;
                    }
                case GEK_Work.GEK5:
                    {
                        loadDTO.GEK = load.HoursForWork;
                        break;
                    }
                case GEK_Work.Practice:
                    {
                        loadDTO.ProizvPractice = load.HoursForWork;
                        break;
                    }
                case GEK_Work.GradBachWorkRecend:
                    {
                        loadDTO.Cons = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPBachMain:
                    {
                        loadDTO.GraduatingBaschelorWork = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPBachAdditional:
                    {
                        loadDTO.GraduatingBaschelorWork = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPSpecMain:
                    {;
                        loadDTO.DP = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPSpecAdditional:
                    {
                        loadDTO.DP = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPMagMain:
                    {
                        loadDTO.DP = load.HoursForWork;
                        break;
                    }
                case GEK_Work.DPMagAdditional:
                    {
                        loadDTO.DP = load.HoursForWork;
                        break;
                    }
            }            
            
            //loadDTO.KP_KR = null;
            //loadDTO.HoursOfLections = null;
            //loadDTO.HoursOfLabWork = null;
            //loadDTO.HoursOfLabWorkAll = null;
            //loadDTO.HoursOfPractWork = null;
            //loadDTO.HoursOfPractWorkAll = null;
            return loadDTO;
        }

        public static ZOLoadDTO ZOLoadDTO(RegularStudyZOLoadSubjects load)
        {
            ZOLoadDTO loadDTO = new ZOLoadDTO();
            loadDTO.Id = load.Id;
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.GroupCount = load.Groups.Count;
            loadDTO.StudentCount = (int)load.StudentCount;
            loadDTO.Term = load.Term;

            //наставная сес
            loadDTO.DateFirst = load.DateFirst;
            loadDTO.LectionCountFirst = load.LectionCountFirst;
            loadDTO.PracticeLabCountFirst = load.PracticeLabCountFirst;
            loadDTO.PracticeLabCountFirstAll = load.PracticeLabCountFirstAll;

            loadDTO.DZ = load.DZ;
            loadDTO.BetweenSessionConsult = load.BetweenSessionConsult;

            //зачетная
            loadDTO.DateSecond = load.DateSecond;
            loadDTO.LectionCountSecond = load.LectionCountSecond;
            loadDTO.PracticeCountSecond = load.PracticeCountSecond;
            loadDTO.PracticeCountSecondAll = load.PracticeCountSecondAll;
            loadDTO.LabCountSecond = load.LabCountSecond;
            loadDTO.LabCountSecondAll = load.LabCountSecondAll;

            loadDTO.HoursForCourseWork = load.HoursForCourseWork;

            loadDTO.Cons = load.Cons;
            loadDTO.ConsAll = load.ConsAll;
            loadDTO.ExamHours = null;
            loadDTO.DivHours = null;
            if (load.FormOfControl == FormOfControl.FormControlExam)
            {
                loadDTO.ExamHours = load.HoursForControl;
            }
            else if (load.FormOfControl == FormOfControl.FormControlDiv || load.FormOfControl == FormOfControl.FormControlZach)
            {
                loadDTO.DivHours = load.HoursForControl;
            }

            loadDTO.AllHours = load.AllHours;

            if (load.Teacher != null)
            {
                loadDTO.TeacherName = load.Teacher.ToString();
                loadDTO.TeacherId = load.Teacher.Id;
            }

            loadDTO.PartOfYear = load.PartOfYear;
            loadDTO.Npr = load.Npr;
            loadDTO.CreditsECTS = load.CreditsECTS;
            loadDTO.SelfWorkHours = load.SelfWorkHours;
            return loadDTO;
        }

        public static ZOLoadDTO ZOLoadDTO(RegularStudyDayLoadGEK load)
        {
            ZOLoadDTO loadDTO = new ZOLoadDTO();
            loadDTO.Id = load.Id;
            loadDTO.SubjectName = load.Subject.Name;
            loadDTO.Grade = load.Groups.FirstOrDefault().Grade;
            loadDTO.GroupCount = load.GroupCount;
            loadDTO.StudentCount = load.StudentCount;
            loadDTO.Term = load.Term;

            //наставная сес
            //loadDTO.DateFirst = null;
            //loadDTO.LectionCountFirst = null;
            //loadDTO.PracticeLabCountFirst = null;
            //loadDTO.PracticeLabCountFirstAll = null;

            //loadDTO.DZ = null;
            //loadDTO.BetweenSessionConsult = null;

            //зачетная
            //loadDTO.DateSecond = null;
            //loadDTO.LectionCountSecond = null;
            //loadDTO.PracticeCountSecond = null;
            //loadDTO.PracticeCountSecondAll = null;
            //loadDTO.LabCountSecond = null;
            //loadDTO.LabCountSecondAll = null;

            loadDTO.HoursForCourseWork = load.HoursForWork;

            //loadDTO.Cons = null;
            //loadDTO.ConsAll = null;

            //loadDTO.ExamHours = null;
            //loadDTO.DivHours = null;


            loadDTO.AllHours = load.HoursForWork;

            if (load.Teacher != null)
            {
                loadDTO.TeacherName = load.Teacher.ToString();
                loadDTO.TeacherId = load.Teacher.Id;
            }

            if (load.Term % 2 == 0)
            { 
                loadDTO.PartOfYear = "Весна";
            }
            else
            {
                loadDTO.PartOfYear = "Осень";
            }
            loadDTO.Npr = (double)load.Npr;
            //loadDTO.CreditsECTS = null;
            //loadDTO.SelfWorkHours = null;
            return loadDTO;
        }
    }
}
