using Schedule.EF.Interfaces;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schedule.EF.Repositories
{
    public class FileRepository : IRepository<FileModel>
    {
        private ScheduleContext db;

        public FileRepository(ScheduleContext context)
        {
            this.db = context;
        }

        public IEnumerable<FileModel> GetAll()
        {
            return db.Files;
        }

        public FileModel Get(int id)
        {
            return db.Files.Find(id);
        }

        public void Create(FileModel file)
        {
            db.Files.Add(file);
        }

        public void Update(FileModel file)
        {
            db.Entry(file).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            FileModel file = db.Files.Find(id);
            if (file != null)
                db.Files.Remove(file);
        }
    }
}