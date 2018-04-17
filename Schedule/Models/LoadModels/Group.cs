using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Caf { get; set; }
        public string Speciality { get; set; }
        public int Grade { get; set; }
        public int? StudentCount { get; set; }


        public GroupKind GroupKind { get; set; }
        public GroupClassesKind GroupClassesKind { get; set; }
        //public bool IsFRL { get; set; }
    }
}