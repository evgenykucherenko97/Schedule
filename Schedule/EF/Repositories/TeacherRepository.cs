using Schedule.EF.Interfaces;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public TeacherModel Get(int id)
        {
            return db.TeacherModels.Find(id);
        }

        public void Create(TeacherModel teacher)
        {
            db.TeacherModels.Add(teacher);
        }

        public void Update(TeacherModel teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TeacherModel teacher = db.TeacherModels.Find(id);
            if (teacher != null)
                db.TeacherModels.Remove(teacher);
        }
    }
}