using Schedule.EF.Repositories;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.EF
{
    public class UnitOfWork : IDisposable
    {
        private ScheduleContext db = new ScheduleContext();

        private DegreeRepository degreeRepository;
        private FileRepository fileRepository;
        private GroupRepository groupRepository;
        private PositionRepository positionRepository;
        private TeacherRepository teacherRepository;

        public DegreeRepository Degrees
        {
            get
            {
                if (degreeRepository == null)
                    degreeRepository = new DegreeRepository(db);
                return degreeRepository;
            }
        }
        public FileRepository Files
        {
            get
            {
                if (fileRepository == null)
                    fileRepository = new FileRepository(db);
                return fileRepository;
            }
        }
        public GroupRepository Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }
        public PositionRepository Positions
        {
            get
            {
                if (positionRepository == null)
                    positionRepository = new PositionRepository(db);
                return positionRepository;
            }
        }
        public TeacherRepository Teachers
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(db);
                return teacherRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}