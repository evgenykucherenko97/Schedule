using Schedule.Models.HelpingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class DayLoadRegular
    {
        public Guid Id { get; set; }
        public string LoadName { get; set; }
        public LoadKind LoadKind { get; set; }
        public StudentKind StudentKind { get; set; }


        public ICollection<RegularStudyDayLoadSubjects> regularStudyDayLoadSubjects { get; set; }
        public ICollection<RegularStudyDayLoadGEK> gekLoadModels { get; set; }
        public ICollection<FileModel> Files { get; set; }
        public DayLoadRegular()
        {
            Id = Guid.NewGuid();
            regularStudyDayLoadSubjects = new List<RegularStudyDayLoadSubjects>();
            gekLoadModels = new List<RegularStudyDayLoadGEK>();
            Files = new List<FileModel>();
        }
    }
}