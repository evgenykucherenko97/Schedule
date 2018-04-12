using Schedule.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Schedule.DAL.Interfaces
{
    //содержит ссылки на менеджеры идентити и репозиторий пользователей
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
