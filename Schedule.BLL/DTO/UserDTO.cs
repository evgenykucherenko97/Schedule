using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.BLL.DTO
{
    //Через данный класс мы будем передавать информацию о пользователях на уровень представления 
    //или, наоборот, получать с этого уровня данные. 
    //Данный класс содержит все основные свойства, 
    //соответствующие свойствам моделей ApplicationUser и ClientProfile.
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
