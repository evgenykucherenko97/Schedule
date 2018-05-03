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

        [Display(Name = "Название предмета")]
        public string SubjectName { get; set; }

        [Display(Name = "Курс")]
        public int Grade { get; set; }

        [Display(Name = "Кол групп")]
        public int GroupCount { get; set; }

        [Display(Name = "Кол студентов")]
        public int StudentCount { get; set; }

        [Display(Name = "Семестр")]
        public int Term { get; set; }



        [Display(Name = "ДЗ")]
        public double? DZ { get; set; }

        [Display(Name = "Лекции")]
        public double? HoursOfLections { get; set; }

        [Display(Name = "Час")]
        public double? HoursOfLabWork { get; set; }

        [Display(Name = "Всего")]
        public double? HoursOfLabWorkAll { get; set; }

        [Display(Name = "Час")]
        public double? HoursOfPractWork { get; set; }

        [Display(Name = "Всего")]
        public double? HoursOfPractWorkAll { get; set; }




        [Display(Name = "КП КР")]
        public double? KP_KR { get; set; }

        [Display(Name = "Конс")]
        public double? Cons { get; set; }



        [Display(Name = "Экз час")]
        public double? ExamHours { get; set; }

        [Display(Name = "Зачет час")]
        public double? DivHours { get; set; }



        [Display(Name = "Вып раб бак")]
        public double? GraduatingBaschelorWork { get; set; }

        [Display(Name = "ДП")]
        public double? DP { get; set; }

        [Display(Name = "Произв ПР")]
        public double? ProizvPractice { get; set; }

        [Display(Name = "Пред ДП")]
        public double? PreDiplomPractice { get; set; }

        [Display(Name = "Магистратура")]
        public double? Magistr { get; set; }

        [Display(Name = "Аспирантура")]
        public double? Aspir { get; set; }

        [Display(Name = "GEK")]
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