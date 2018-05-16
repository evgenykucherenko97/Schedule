using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule.Models
{
    public class TeacherModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Ученая степень")]
        public Degree Degree { get; set; }
        public Guid? IdDegree { get; set; }

        [Display(Name = "Должность")]
        public PositionModel Position { get; set; }
        public Guid? IdPosition { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name[0] + "." + SecondName[0] + ".";
        }
    }
}