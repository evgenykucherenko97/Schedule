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
    public class TeacherRepository : IRepository<TeacherModel>
    {
        private ScheduleContext db;

        public TeacherRepository(ScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<TeacherModel> GetAll()
        {
            return db.TeacherModels;
        }

        public async Task<IEnumerable<TeacherModel>> GetAllAsync()
        {
            return await db.TeacherModels.ToListAsync();
        }

        public TeacherModel Get(Guid id)
        {
            return db.TeacherModels.Find(id);
        }

        public async Task<TeacherModel> GetAsync(Guid? id)
        {
            return await db.TeacherModels.FindAsync(id);
        }

        public void Create(TeacherModel teacher)
        {
            db.TeacherModels.Add(teacher);
        }

        public void Update(TeacherModel teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            TeacherModel teacher = db.TeacherModels.Find(id);
            if (teacher != null)
                db.TeacherModels.Remove(teacher);
        }
    }
}