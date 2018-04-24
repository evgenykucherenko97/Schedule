using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }

        [Display(Name="Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Ученая степень")]
        public string Degree { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }
    }
}