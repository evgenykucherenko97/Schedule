using Schedule.Models.DTOs;
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

        //public DbSet<DayLoadDTO> DayLoadDTOs { get; set; }
        //public DbSet<ZOLoadDTO> ZOLoadDTOs { get; set; }

        public DbSet<DayLoadRegular> DayLoadRegulars { get; set; }
        public DbSet<RegularStudyDayLoadSubjects> RegularStudyDayLoadSubjects { get; set; }
        public DbSet<RegularStudyDayLoadGEK> RegularStudyDayLoadGEKs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasMany(c => c.RegularStudyDayLoadSubjects)
                .WithMany(s => s.Groups)
                .Map(t => t.MapLeftKey("GroupId")
                .MapRightKey("RegularStudyDayLoadSubjectsId")
                .ToTable("GroupRegularStudyDayLoadSubjects"));
            modelBuilder.Entity<Group>().HasMany(c => c.RegularStudyDayLoadGEK)
                .WithMany(s => s.Groups)
                .Map(t => t.MapLeftKey("GroupId")
                .MapRightKey("RegularStudyDayLoadGEKId")
                .ToTable("GroupRegularStudyDayLoadGEK"));
        }

    }
}