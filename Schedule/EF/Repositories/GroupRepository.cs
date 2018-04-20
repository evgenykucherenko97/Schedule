using Schedule.EF.Interfaces;
using Schedule.Models;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Schedule.EF.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private ScheduleContext db;

        public GroupRepository(ScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Group> GetAll()
        {
            return db.Groups;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await db.Groups.ToListAsync();
        }

        public Group Get(Guid id)
        {
            return db.Groups.Find(id);
        }

        public async Task<Group> GetAsync(Guid id)
        {
            return await db.Groups.FindAsync(id);
        }

        public void Create(Group group)
        {
            db.Groups.Add(group);
        }

        public void Update(Group group)
        {
            db.Entry(group).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Group group = db.Groups.Find(id);
            if (group != null)
                db.Groups.Remove(group);
        }
    }
}