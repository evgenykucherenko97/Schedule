using Microsoft.AspNet.Identity;
using Schedule.DAL.Entities;

namespace Schedule.DAL.Identity
{
    //Добавляет пользователей в БД и аутентифицирует
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
