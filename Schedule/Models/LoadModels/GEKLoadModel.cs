using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.LoadModels
{
    public class GEKLoadModel
    {
        public Guid Id { get; set; }
        public string LoadName { get; set; }
        public Subject Subject { get; set; }
        //groups
        public List<Group> Groups { get; set; }


        //teacher
        public TeacherModel Teacher { get; set; }
        public int Term { get; set; }

        public double? Cons { get; set; }


        #region
        //GEK hours
        public double? GraduatingBaschelorWork { get; set; }
        public double? DP { get; set; }
        public double? ProizvPractice { get; set; }
        public double? PreDiplomPractice { get; set; }
        public double? Magistr { get; set; }
        public double? Aspir { get; set; }
        public double? GEK { get; set; }
        #endregion

        public double AllCredits { get; set; }
        
    }
}