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

        public async Task<IEnumerable<PositionModel>> GetAllAsync()
        {
            return await db.Positions.ToListAsync();
        }

        public PositionModel Get(Guid id)
        {
            return db.Positions.Find(id);
        }

        public async Task<PositionModel> GetAsync(Guid? id)
        {
            return await db.Positions.FindAsync(id);
        }

        public void Create(PositionModel position)
        {
            db.Positions.Add(position);
        }

        public void Update(PositionModel position)
        {
            db.Entry(position).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            PositionModel position = db.Positions.Find(id);
            if (position != null)
                db.Positions.Remove(position);
        }
    }
}