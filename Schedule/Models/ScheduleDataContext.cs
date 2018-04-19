using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<PositionModel> Positions { get; set; }
        public DbSet<TeacherModel> TeacherModels { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}