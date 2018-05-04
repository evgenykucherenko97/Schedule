using Schedule.Models.HelpingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class ZOLoadRegular
    {
        public Guid Id { get; set; }
        public string LoadName { get; set; }
        public LoadKind LoadKind { get; set; }
        public StudentKind StudentKind { get; set; }


        public ICollection<RegularStudyZOLoadSubjects> regularStudyZOLoadSubjects { get; set; }
        //public ICollection<RegularStudyZOLoadGEK> gekLoadModelZOs { get; set; }
        public ZOLoadRegular()
        {
            Id = Guid.NewGuid();
            regularStudyZOLoadSubjects = new List<RegularStudyZOLoadSubjects>();
            //gekZOLoadModels = new List<RegularStudyZOLoadGEK>();
        }
    }
}