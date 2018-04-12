using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Schedule.DAL.Entities;

namespace Schedule.DAL.Identity
{

    //выполняют по сути роль репозиториев
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
