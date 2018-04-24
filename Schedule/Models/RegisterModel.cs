using System;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class RegisterModel
    {   
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

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
