using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class DayLoadDTO
    {
        public Guid Id { get; set; }
        //public Guid? LoadId { get; set; }

        [Display(Name = "Название_учебного_предмета")]
        public string SubjectName { get; set; }

        [Display(Name = "Курс")]
        public int Grade { get; set; }

        [Display(Name = "Количество групп")]
        public int GroupCount { get; set; }

        [Display(Name = "  Колтчество студентов")]
        public int StudentCount { get; set; }

        [Display(Name = "Семестр")]
        public int Term { get; set; }



        [Display(Name = "Домашнее задание")]
        public double? DZ { get; set; }

        [Display(Name = "Лекции")]
        public double? HoursOfLections { get; set; }

        [Display(Name = "Час/группа")]
        public double? HoursOfLabWork { get; set; }

        [Display(Name = "Всего")]
        public double? HoursOfLabWorkAll { get; set; }

        [Display(Name = "Час/группа")]
        public double? HoursOfPractWork { get; set; }

        [Display(Name = "Всего")]
        public double? HoursOfPractWorkAll { get; set; }




        [Display(Name = "Курсовой проект/работа")]
        public double? KP_KR { get; set; }

        [Display(Name = "Консультация")]
        public double? Cons { get; set; }



        [Display(Name = "Часов для экзамена")]
        public double? ExamHours { get; set; }

        [Display(Name = "Часы под зачет")]
        public double? DivHours { get; set; }



        [Display(Name = "Выпускная работа бакалавра")]
        public double? GraduatingBaschelorWork { get; set; }

        [Display(Name = "ДП")]
        public double? DP { get; set; }

        [Display(Name = "Производственная Практика")]
        public double? ProizvPractice { get; set; }

        [Display(Name = "ПредДП")]
        public double? PreDP { get; set; }

        [Display(Name = "Магистратура")]
        public double? Magistr { get; set; }

        [Display(Name = "Аспирантура")]
        public double? Aspir { get; set; }

        [Display(Name = "работа в GEK")]
        public double? GEK { get; set; }

        [Display(Name = "Самостоятельная работа")]
        public double? SelfWork { get; set; }

        [Display(Name = "Всего часов")]
        public double? AllHours { get; set; }



        [Display(Name = "Преподаватель")]
        public string TeacherName { get; set; }
        public Guid? TeacherId { get; set; }
    }
}