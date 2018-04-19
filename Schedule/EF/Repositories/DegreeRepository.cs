using Schedule.EF.Interfaces;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public Degree Get(int id)
        {
            return db.Degrees.Find(id);
        }

        public void Create(Degree degree)
        {
            db.Degrees.Add(degree);
        }

        public void Update(Degree degree)
        {
            db.Entry(degree).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Degree degree = db.Degrees.Find(id);
            if (degree != null)
                db.Degrees.Remove(degree);
        }
    }
}