using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.HelpingModels
{
    public enum LoadKind
    {
        Day = 1,
        ZO = 2,
        None = 3
    }
    public enum StudentKind
    {
        Native = 1,
        Foreigners = 2,
        none = 3
    }
    public class LoadHelperModel
    {
        public string Name { get; set; }
        public LoadKind LoadKind { get; set; }
        public StudentKind StudentKind { get; set; }
        public string Filepath { get; set; }
    }
}