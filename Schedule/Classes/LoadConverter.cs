using Schedule.Models;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Classes
{
    public static class LoadConverter
    {
        public static List<RegularStudyDayLoadSubjects> FromDTOtoListOfDayRegularLoads(TableDataDTODay tableDataDTODay)
        {
            ScheduleContext db = new ScheduleContext();
            List<RegularStudyDayLoadSubjects> loads = new List<RegularStudyDayLoadSubjects>();
            string[] groupNames = tableDataDTODay.Groups.Split(null);

            List<Group> groups = new List<Group>();
            foreach (string group in groupNames)
            {
                groups.Add(db.Groups.Where(p => p.Name == group).FirstOrDefault());
            }
            RegularStudyDayLoadSubjects temp;
            //for lector
            if ((tableDataDTODay.LectionCountPerFirstHalf != null || tableDataDTODay.LectionCountPerSecondHalf != null) &&
                (tableDataDTODay.LectionCountPerFirstHalf != 0 || tableDataDTODay.LectionCountPerSecondHalf != 0))
            {
                temp = new RegularStudyDayLoadSubjects();
                temp.Id = Guid.NewGuid();
                temp.KindOfClasses = KindOfClasses.Lections;
                temp.Subject = new Subject()
                {
                    Id = Guid.NewGuid(),
                    Name = tableDataDTODay.SubjectName
                };
                temp.DZ = null;
                temp.Groups = groups;
                temp.StudentCount = 0;
                foreach(var group in temp.Groups)
                {
                    temp.StudentCount += (int)group.StudentCount;
                    temp.Subject.Name += ", " + group.Name;
                }
                if ((bool)tableDataDTODay.FormControlZach)
                {
                    temp.FormOfControl = FormOfControl.FormControlZach;
                    temp.HoursForControl = 2;
                    temp.Cons = null;
                }
                if ((bool)tableDataDTODay.FormControlDiv)
                {
                    temp.FormOfControl = FormOfControl.FormControlDiv;
                    temp.HoursForControl = 2;
                    temp.Cons = null;
                }
                if ((bool)tableDataDTODay.FormControlExam)
                {
                    temp.FormOfControl = FormOfControl.FormControlExam;
                    temp.HoursForControl = temp.StudentCount / 3.0303;
                    temp.Cons = temp.Groups.Count * 2;
                }
                temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                temp.Term = tableDataDTODay.Term;
                temp.CourseWork = CourseWork.None;
                temp.HoursForCourseWork = null;
                temp.HoursOfWork = tableDataDTODay.LectionCountPerFirstHalf + tableDataDTODay.LectionCountPerSecondHalf;
                temp.HoursOfWorkAll = temp.HoursOfWork;
                temp.AllCredits = (double)temp.HoursOfWorkAll + (double)temp.HoursForControl;
                if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                loads.Add(temp);
            }

            if ((tableDataDTODay.LabCountPerFirstHalf != null || tableDataDTODay.LabCountPerSecondHalf != null) &&
                (tableDataDTODay.LabCountPerFirstHalf != 0 || tableDataDTODay.LabCountPerSecondHalf != 0))
            {
                foreach (var group in groups)
                {                    
                    temp = new RegularStudyDayLoadSubjects();
                    temp.Id = Guid.NewGuid();
                    temp.KindOfClasses = KindOfClasses.Labs;
                    temp.Subject = new Subject()
                    {
                        Id = Guid.NewGuid(),
                        Name = tableDataDTODay.SubjectName
                    };
                    temp.DZ = null;
                    temp.Groups = new List<Group>();
                    temp.Groups.Add(group);
                    temp.StudentCount = (int)group.StudentCount;
                    temp.DZ = temp.StudentCount / 2.0 * (tableDataDTODay.RK + tableDataDTODay.RGR + tableDataDTODay.RR);
                    temp.Subject.Name += ", " + group.Name;                    
                    if ((bool)tableDataDTODay.FormControlZach)
                    {
                        temp.FormOfControl = FormOfControl.FormControlZach;                   
                    }
                    if ((bool)tableDataDTODay.FormControlDiv)
                    {
                        temp.FormOfControl = FormOfControl.FormControlDiv;
                    }
                    if ((bool)tableDataDTODay.FormControlExam)
                    {
                        temp.FormOfControl = FormOfControl.FormControlExam;
                    }
                    temp.HoursForControl = null;
                    temp.Cons = null;
                    temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                    temp.Term = tableDataDTODay.Term;
                    temp.HoursOfWork = tableDataDTODay.LabCountPerFirstHalf + tableDataDTODay.LabCountPerSecondHalf;
                    temp.HoursOfWorkAll = temp.HoursOfWork;
                    #region
                    //course
                    if(tableDataDTODay.CourserWork != null && tableDataDTODay.CourserWork != 0)
                    {
                        temp.CourseWork = CourseWork.CourseWork;
                        temp.HoursForCourseWork = temp.StudentCount * 3;
                    }
                    else if (tableDataDTODay.CourseProject != null && tableDataDTODay.CourseProject != 0)
                    {
                        temp.CourseWork = CourseWork.CourseProject;
                        temp.HoursForCourseWork = temp.StudentCount * 4;
                    }
                    #endregion
                    //temp.CourseWork = CourseWork.None;
                    //temp.HoursForCourseWork = null;
                    temp.AllCredits = (double)temp.HoursOfWorkAll;
                    if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                    if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                    if (temp.HoursForCourseWork != null) temp.AllCredits += (double)temp.HoursForCourseWork; 
                    loads.Add(temp);
                }                
            }

            if ((tableDataDTODay.PracticeCountPerFirstHalf != null || tableDataDTODay.PracticeCountPerSecondHalf != null) &&
                (tableDataDTODay.PracticeCountPerFirstHalf != 0 || tableDataDTODay.PracticeCountPerSecondHalf != 0))
            {
                foreach (var group in groups)
                {
                    temp = new RegularStudyDayLoadSubjects();
                    temp.Id = Guid.NewGuid();
                    temp.KindOfClasses = KindOfClasses.Labs;
                    temp.Subject = new Subject()
                    {
                        Id = Guid.NewGuid(),
                        Name = tableDataDTODay.SubjectName
                    };
                    temp.Groups = new List<Group>();
                    temp.Groups.Add(group);
                    temp.StudentCount = (int)group.StudentCount;
                    if (tableDataDTODay.LabCountPerFirstHalf == null || tableDataDTODay.LabCountPerSecondHalf == null)
                        temp.DZ = temp.StudentCount / 2.0 * (tableDataDTODay.RK + tableDataDTODay.RGR + tableDataDTODay.RR);
                    temp.Subject.Name += ", " + group.Name;
                    if ((bool)tableDataDTODay.FormControlZach)
                    {
                        temp.FormOfControl = FormOfControl.FormControlZach;
                    }
                    if ((bool)tableDataDTODay.FormControlDiv)
                    {
                        temp.FormOfControl = FormOfControl.FormControlDiv;
                    }
                    if ((bool)tableDataDTODay.FormControlExam)
                    {
                        temp.FormOfControl = FormOfControl.FormControlExam;
                    }
                    temp.HoursForControl = null;
                    temp.Cons = null;
                    temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                    temp.Term = tableDataDTODay.Term;
                    temp.HoursOfWork = tableDataDTODay.PracticeCountPerFirstHalf + tableDataDTODay.PracticeCountPerSecondHalf;
                    temp.HoursOfWorkAll = temp.HoursOfWork;

                    #region
                    //course
                    if (tableDataDTODay.CourserWork != null && tableDataDTODay.CourserWork != 0)
                    {
                        temp.CourseWork = CourseWork.CourseWork;
                        temp.HoursForCourseWork = temp.StudentCount * 3;
                    }
                    else if (tableDataDTODay.CourseProject != null && tableDataDTODay.CourseProject != 0)
                    {
                        temp.CourseWork = CourseWork.CourseProject;
                        temp.HoursForCourseWork = temp.StudentCount * 4;
                    }
                    #endregion

                    temp.AllCredits = (double)temp.HoursOfWorkAll;
                    if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                    if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                    if (temp.HoursForCourseWork != null) temp.AllCredits += (double)temp.HoursForCourseWork;
                    loads.Add(temp);
                }
            }

            //    \
            //    tableDataDTODay.SubjectName;
            //public string Faculty { get; set; } +
            //public string Caf { get; set; } +
            //public string Speciality { get; set; } +
            //public int Grade { get; set; } +
            //public int Term { get; set; } +
            //public string Groups { get; set; } +
            //public int GroupCount { get; set; } +
            //public int StudentCount { get; set; } +

            //public int? LectionCountAWeekPerFirstHalf { get; set; } +
            //public int? LectionCountPerFirstHalf { get; set; } +
            //public int? LabCountAWeekPerFirstHalf { get; set; } +
            //public int? LabCountPerFirstHalf { get; set; } +
            //public int? PracticeCountAWeekPerFirstHalf { get; set; } +
            //public int? PracticeCountPerFirstHalf { get; set; } +

            //public int? LectionCountAWeekPerSecondHalf { get; set; } +
            //public int? LectionCountPerSecondHalf { get; set; } +
            //public int? LabCountAWeekPerSecondHalf { get; set; } +
            //public int? LabCountPerSecondHalf { get; set; } +
            //public int? PracticeCountAWeekPerSecondHalf { get; set; } +
            //public int? PracticeCountPerSecondHalf { get; set; } +

            //public int? RGR { get; set; } +
            //public int? RR { get; set; } +
            //public int? RK { get; set; } +
            //public int? CourserWork { get; set; } +
            //public int? CourseProject { get; set; } +

            //public bool? FormControlZach { get; set; } +
            //public bool? FormControlDiv { get; set; } +
            //public bool? FormControlExam { get; set; } +

            //public double AllCredits { get; set; }
            //public double SelfWorkHours { get; set; } +
            //public double StudyLoad { get; set; }
            //public double Npr { get; set; }
            return loads;
        }

        public static RegularStudyZOLoadSubjects FromDTOtoZORegularLoad(TableDataDTOZaoch tableDataDTOZaoch)
        {
            ScheduleContext db = new ScheduleContext();
            RegularStudyZOLoadSubjects load = new RegularStudyZOLoadSubjects();
            string[] groupNames = tableDataDTOZaoch.Groups.Split(null);           
            foreach (string group in groupNames)
            {
                load.Groups.Add(db.Groups.Where(p => p.Name == group).FirstOrDefault());
            }
            load.setStudentCount();
            load.Term = tableDataDTOZaoch.Term;
            load.setPartOfYear();
            load.Subject = new Subject()
            {
                Id = Guid.NewGuid(),
                Name = tableDataDTOZaoch.SubjectName
            };
            foreach (var group in load.Groups)
            {
                load.Subject.Name += ", " + group.Name;
            }
            if ((bool)tableDataDTOZaoch.FormControlZach)
            {
                load.FormOfControl = FormOfControl.FormControlZach;
            }
            if ((bool)tableDataDTOZaoch.FormControlDiv)
            {
                load.FormOfControl = FormOfControl.FormControlDiv;
            }
            if ((bool)tableDataDTOZaoch.FormControlExam)
            {
                load.FormOfControl = FormOfControl.FormControlExam;
            }
            load.setHoursForControl();
            load.DZ = load.StudentCount / 2.0 * (tableDataDTOZaoch.RK + tableDataDTOZaoch.RGR + tableDataDTOZaoch.RR);
            load.DateFirst = "";
            load.LectionCountFirst = tableDataDTOZaoch.LectionCountFirst;
            load.LectionCountSecond = 0;
            load.PracticeLabCountFirst = tableDataDTOZaoch.LabCountFirst + tableDataDTOZaoch.PracticeFirst;
            load.PracticeLabCountFirstAll = load.PracticeLabCountFirst;
            load.BetweenSessionConsult = (double)tableDataDTOZaoch.BetweenSessionConsult;
            load.DateSecond = "";
            load.LabCountSecond = tableDataDTOZaoch.LabCountSecond;
            load.LabCountSecondAll = load.LabCountSecond;
            load.PracticeCountSecond = tableDataDTOZaoch.PracticeSecond;
            load.PracticeCountSecondAll = load.PracticeCountSecond;
            load.Cons = tableDataDTOZaoch.ConsultBeforeExamOrDiv;
            load.ConsAll = load.Cons;
            load.AllHours = tableDataDTOZaoch.AllHours;
            load.Npr = tableDataDTOZaoch.Npr;
            load.CreditsECTS = (double)tableDataDTOZaoch.CreditsECTS;
            load.SelfWorkHours = tableDataDTOZaoch.SelfWorkHours;
            //course
            load.CourseWork = CourseWork.None;
            if (tableDataDTOZaoch.CourserWork != null && tableDataDTOZaoch.CourserWork != 0)
            {
                load.CourseWork = CourseWork.CourseWork;
            }
            else if (tableDataDTOZaoch.CourseProject != null && tableDataDTOZaoch.CourseProject != 0)
            {
                load.CourseWork = CourseWork.CourseProject;
            }
            load.setHoursForCourseWork();
            return load;
        }
    }
}