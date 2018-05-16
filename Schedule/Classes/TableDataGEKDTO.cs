using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Classes
{
    public enum GEK_Work
    {
        GradBachWorkRecend = 1,
        Practice = 2,
        GEK4 = 3,
        DPBachMain = 41,
        DPBachAdditional = 42,
        DPMagMain = 51,
        DPMagAdditional = 52,
        DPSpecMain = 61,
        DPSpecAdditional = 62,
        GEK5 = 7
    }
    public class TableDataGEKDTO
    {
        public Guid Id { get; set; }
        public GEK_Work GEK_Work { get; set; }
        public int? AdditionalParam { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }
        public int Faculty { get; set; }
        public string Speciality { get; set; }
        public double StudyLoad { get; set; }
        public double Npr { get; set; }
    }
}