using Schedule.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Schedule.DAL.Interfaces
{
    //управляет профилями пользователей
    public interface IClientManager : IDisposable
    {
        IEnumerable<ClientProfile> GetAll();
        ClientProfile Get(string id);
        void Update(ClientProfile item);
        void Delete(string id);
        void Create(ClientProfile item);
    }
}
