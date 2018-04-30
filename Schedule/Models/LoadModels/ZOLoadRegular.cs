using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class ZOLoadRegular
    {
        public Guid Id { get; set; }

        public List<RegularStudyZOLoadSubjects> regularStudyZOLoadSubjects;
        //public List<RegularStudyZOLoadGEK> gekZOLoadModels;
        public ZOLoadRegular()
        {
            Id = Guid.NewGuid();
            regularStudyZOLoadSubjects = new List<RegularStudyZOLoadSubjects>();
            //gekZOLoadModels = new List<RegularStudyZOLoadGEK>();
        }
    }
}