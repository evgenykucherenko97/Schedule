using Schedule.EF.Interfaces;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Schedule.EF.Repositories
{
    public class DegreeRepository : IRepository<Degree>
    {
        private ScheduleContext db;

        public DegreeRepository(ScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Degree> GetAll()
        {
            return db.Degrees;
        }

        public async Task<IEnumerable<Degree>> GetAllAsync()
        {
            return await db.Degrees.ToListAsync();
        }

        public Degree Get(Guid id)
        {
            return db.Degrees.Find(id);
        }

        public async Task<Degree> GetAsync(Guid? id)
        {
            return await db.Degrees.FindAsync(id);
        }

        public void Create(Degree degree)
        {
            db.Degrees.Add(degree);
        }

        public void Update(Degree degree)
        {
            db.Entry(degree).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Degree degree = db.Degrees.Find(id);
            if (degree != null)
                db.Degrees.Remove(degree);
        }
    }
}