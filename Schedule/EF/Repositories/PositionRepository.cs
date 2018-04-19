using Schedule.EF.Interfaces;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schedule.EF.Repositories
{
    public class PositionRepository : IRepository<PositionModel>
    {
        private ScheduleContext db;

        public PositionRepository(ScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<PositionModel> GetAll()
        {
            return db.Positions;
        }

        public PositionModel Get(int id)
        {
            return db.Positions.Find(id);
        }

        public void Create(PositionModel position)
        {
            db.Positions.Add(position);
        }

        public void Update(PositionModel position)
        {
            db.Entry(position).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PositionModel position = db.Positions.Find(id);
            if (position != null)
                db.Positions.Remove(position);
        }
    }
}