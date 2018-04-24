using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class EditModelForAdmin
    {
        public string Id { get; set; }
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }        

        [Display(Name = "Адрес")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Роль")]
        [Required]
        public Roles Role { get; set; }
    }
}