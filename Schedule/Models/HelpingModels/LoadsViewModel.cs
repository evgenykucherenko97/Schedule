using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.HelpingModels
{
    public class LoadsViewModel
    {
        public IEnumerable<DayLoadRegular> DayLoadRegulars { get; set; }
        public IEnumerable<ZOLoadRegular> ZOLoadRegulars { get; set; }
    }
}