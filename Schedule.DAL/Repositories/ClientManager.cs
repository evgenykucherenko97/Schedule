using System;
using System.Collections.Generic;
using Schedule.DAL.EF;
using Schedule.DAL.Entities;
using Schedule.DAL.Interfaces;
using System.Data.Entity;

namespace Schedule.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
       
        public IEnumerable<ClientProfile> GetAll()
        {
            return Database.ClientProfiles;
        }

        public ClientProfile Get(string id)
        {
            return Database.ClientProfiles.Find(id);
        }

        public void Update(ClientProfile item)
        {
            Database.Entry(item).State = EntityState.Modified;
            Database.SaveChanges();
        }

        public void Delete(string id)
        {
            ClientProfile item = Database.ClientProfiles.Find(id);
            if (item != null)
                Database.ClientProfiles.Remove(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
