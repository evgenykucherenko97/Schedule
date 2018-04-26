using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class DayLoadRegular
    {
        public Guid Id { get; set; }

        public List<RegularStudyDayLoadSubjects> regularStudyDayLoadSubjects;
        public List<RegularStudyDayLoadGEK> gekLoadModels;
        public DayLoadRegular()
        {
            Id = Guid.NewGuid();
            regularStudyDayLoadSubjects = new List<RegularStudyDayLoadSubjects>();
            gekLoadModels = new List<RegularStudyDayLoadGEK>();
        }
    }
}