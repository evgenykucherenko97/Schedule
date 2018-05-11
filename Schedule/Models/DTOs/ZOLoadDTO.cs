using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class ZOLoadDTO
    {
        public Guid Id { get; set; }
        [Display(Name = "Название_учебного_предмета")]
        public string SubjectName { get; set; }
        [Display(Name = "Курс")]
        public int Grade { get; set; }
        [Display(Name = "Количество групп")]
        public int GroupCount { get; set; }
        [Display(Name = "Количество студентов")]
        public int StudentCount { get; set; }
        [Display(Name = "Семестр")]
        public int Term { get; set; }

        //наставная сес
        [Display(Name = "Дата")]
        public string DateFirst { get; set; }
        [Display(Name = "Час лекций")]
        public int? LectionCountFirst { get; set; }
        [Display(Name = "Час практик")]
        public int? PracticeLabCountFirst { get; set; }
        [Display(Name = "Всего")]
        public int? PracticeLabCountFirstAll { get; set; }

        [Display(Name = "Домашнее задание")]
        public double? DZ { get; set; }
        [Display(Name = "Межсессионная конмультация")]
        public double? BetweenSessionConsult { get; set; }

        //зачетная
        [Display(Name = "Дата")]
        public string DateSecond { get; set; }
        [Display(Name = "Час лекций")]
        public int? LectionCountSecond { get; set; }
        [Display(Name = "час практик")]
        public int? PracticeCountSecond { get; set; }
        [Display(Name = "Всего")]
        public int? PracticeCountSecondAll { get; set; }
        [Display(Name = "Час лабораторных")]
        public int? LabCountSecond { get; set; }
        [Display(Name = "ВСего")]
        public int? LabCountSecondAll { get; set; }

        [Display(Name = "Курсовой")]
        public double? HoursForCourseWork { get; set; }

        [Display(Name = "Консультация перед зачетом или экзаменом")]
        public double? Cons { get; set; }
        [Display(Name = "Конс всего")]
        public double? ConsAll { get; set; }

        [Display(Name = "Часы под экзамен")]
        public double? ExamHours { get; set; }
        [Display(Name = "Часы под зачет")]
        public double? DivHours { get; set; }

        [Display(Name = "Всего часов")]
        public double? AllHours { get; set; }

        [Display(Name = "Преподаватель")]
        public string TeacherName { get; set; }
        public Guid? TeacherId { get; set; }

        [Display(Name = "Часть года")]
        public string PartOfYear { get; set; }
        [Display(Name = "Npr")]
        public double Npr { get; set; }
        [Display(Name = "Кредитов ECTS")]
        public double? CreditsECTS { get; set; }
        [Display(Name = "Самостоятельная работа")]
        public double? SelfWorkHours { get; set; }        
    }
}