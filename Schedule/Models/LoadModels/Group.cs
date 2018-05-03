using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule.Models.LoadModels
{
    public class Group
    {
        //Каф +
        //    Порядок 
        //    Код спец-ти +
        //    Название спец-ти 
        //    Курс    +
        //    Номер Группы +   
        //    Кол-во студентов +        
        //    Полное название направления 
        //    Полное название специальности   
        //    Полное название специализации 
        //    Срок обучения
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Номер группы")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Факультет")]
        public string Faculty { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public string Caf { get; set; }

        [Required]
        [Display(Name = "Специальность")]
        public string Speciality { get; set; }

        [Required]
        [Display(Name = "Курс")]
        public int Grade { get; set; }

        [Required]
        [Display(Name = "Количество студентов")]
        public int? StudentCount { get; set; }

        [Display(Name = "Студенты")]
        public GroupKind GroupKind { get; set; }

        [Display(Name = "Форма обучения")]
        public GroupClassesKind GroupClassesKind { get; set; }

        public virtual ICollection<RegularStudyDayLoadSubjects> RegularStudyDayLoadSubjects { get; set; }
        public virtual ICollection<RegularStudyDayLoadGEK> RegularStudyDayLoadGEK { get; set; }
        public Group()
        {
            RegularStudyDayLoadSubjects = new List<RegularStudyDayLoadSubjects>();
            RegularStudyDayLoadGEK = new List<RegularStudyDayLoadGEK>();
        }

    }
}