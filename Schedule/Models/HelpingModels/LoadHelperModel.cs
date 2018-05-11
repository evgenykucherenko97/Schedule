using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name="Название")]
        public string Name { get; set; }
        [Display(Name = "Вид нагрузки")]
        public LoadKind LoadKind { get; set; }
        [Display(Name = "Студенты")]
        public StudentKind StudentKind { get; set; }
        [Display(Name = "Входные данные")]
        public string Filepath { get; set; }
        [Display(Name = "Входные данные GEK")]
        public string Filepath_GEK { get; set; }
    }
}