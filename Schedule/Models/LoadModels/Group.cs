using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Faculty { get; set; }
        public string Caf { get; set; }
        public string Speciality { get; set; }
        public int Grade { get; set; }
        public int? StudentCount { get; set; }

        public bool IsFRL { get; set; }
    }
}