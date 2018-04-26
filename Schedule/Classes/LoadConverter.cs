﻿using Schedule.Models;
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
            if (tableDataDTODay.LectionCountPerFirstHalf != null || tableDataDTODay.LectionCountPerSecondHalf != null)
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
                loads.Add(temp);
            }

            if (tableDataDTODay.LabCountPerFirstHalf != null || tableDataDTODay.LabCountPerSecondHalf != null)
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
                    //temp.CourseWork = CourseWork.None;
                    //temp.HoursForCourseWork = null;
                    loads.Add(temp);
                }                
            }

        //    \
        //    tableDataDTODay.SubjectName;
        //public string Faculty { get; set; }
        //public string Caf { get; set; }
        //public string Speciality { get; set; }
        //public int Grade { get; set; }
        //public int Term { get; set; }
        //public string Groups { get; set; }
        //public int GroupCount { get; set; }
        //public int StudentCount { get; set; }

        //public int? LectionCountAWeekPerFirstHalf { get; set; }
        //public int? LectionCountPerFirstHalf { get; set; }
        //public int? LabCountAWeekPerFirstHalf { get; set; }
        //public int? LabCountPerFirstHalf { get; set; }
        //public int? PracticeCountAWeekPerFirstHalf { get; set; }
        //public int? PracticeCountPerFirstHalf { get; set; }

        //public int? LectionCountAWeekPerSecondHalf { get; set; }
        //public int? LectionCountPerSecondHalf { get; set; }
        //public int? LabCountAWeekPerSecondHalf { get; set; }
        //public int? LabCountPerSecondHalf { get; set; }
        //public int? PracticeCountAWeekPerSecondHalf { get; set; }
        //public int? PracticeCountPerSecondHalf { get; set; }

        //public int? RGR { get; set; }
        //public int? RR { get; set; }
        //public int? RK { get; set; }
        //public int? CourserWork { get; set; }
        //public int? CourseProject { get; set; }

        //public bool? FormControlZach { get; set; }
        //public bool? FormControlDiv { get; set; }
        //public bool? FormControlExam { get; set; }

        //public double AllCredits { get; set; }
        //public double SelfWorkHours { get; set; }
        //public double StudyLoad { get; set; }
        //public double Npr { get; set; }
            return loads;
        }
    }
}