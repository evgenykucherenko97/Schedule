using Schedule.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class RegularStudyDayLoadGEK
    {
        public Guid Id { get; set; }
        
        public Guid? IdLoad { get; set; }
        
        public Subject Subject { get; set; }
        //groups


        public virtual ICollection<Group> Groups { get; set; }
        public RegularStudyDayLoadGEK()
        {
            Id = Guid.NewGuid();
            Groups = new List<Group>();
        }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }

        
        public TeacherModel Teacher { get; set; }
        public int Term { get; set; }

        //public double? Cons { get; set; }


        #region
        //GEK hours
        public GEK_Work GEK_Work { get; set; }
        public double? HoursForWork { get; set; }
        //public double? GraduatingBaschelorWork { get; set; }
        //public double? DP { get; set; }
        //public double? ProizvPractice { get; set; }
        //public double? PreDiplomPractice { get; set; }
        //public double? Magistr { get; set; }
        //public double? Aspir { get; set; }
        //public double? GEK { get; set; }
        #endregion
        public double? Npr { get; set; }
        public double AllCredits { get; set; }
        
    }
}