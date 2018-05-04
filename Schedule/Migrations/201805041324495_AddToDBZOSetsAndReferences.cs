namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDBZOSetsAndReferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegularStudyZOLoadSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadId = c.Guid(),
                        StudentCount = c.Int(),
                        Term = c.Int(nullable: false),
                        DateFirst = c.String(),
                        LectionCountFirst = c.Int(),
                        PracticeLabCountFirst = c.Int(),
                        PracticeLabCountFirstAll = c.Int(),
                        DZ = c.Double(),
                        BetweenSessionConsult = c.Double(nullable: false),
                        DateSecond = c.String(),
                        LectionCountSecond = c.Int(),
                        PracticeCountSecond = c.Int(),
                        PracticeCountSecondAll = c.Int(),
                        LabCountSecond = c.Int(),
                        LabCountSecondAll = c.Int(),
                        CourseWork = c.Int(nullable: false),
                        HoursForCourseWork = c.Double(),
                        Cons = c.Double(),
                        ConsAll = c.Double(),
                        FormOfControl = c.Int(nullable: false),
                        HoursForControl = c.Double(),
                        SelfWorkHours = c.Double(),
                        AllHours = c.Double(),
                        CreditsECTS = c.Double(nullable: false),
                        Npr = c.Double(nullable: false),
                        PartOfYear = c.String(),
                        Subject_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                        ZOLoadRegular_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.TeacherModels", t => t.Teacher_Id)
                .ForeignKey("dbo.ZOLoadRegulars", t => t.ZOLoadRegular_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.ZOLoadRegular_Id);
            
            CreateTable(
                "dbo.ZOLoadRegulars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadName = c.String(),
                        LoadKind = c.Int(nullable: false),
                        StudentKind = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupRegularStudyZOLoadSubjects",
                c => new
                    {
                        GroupId = c.Guid(nullable: false),
                        RegularStudyZOLoadSubjectsId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RegularStudyZOLoadSubjectsId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.RegularStudyZOLoadSubjects", t => t.RegularStudyZOLoadSubjectsId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RegularStudyZOLoadSubjectsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "ZOLoadRegular_Id", "dbo.ZOLoadRegulars");
            DropForeignKey("dbo.GroupRegularStudyZOLoadSubjects", "RegularStudyZOLoadSubjectsId", "dbo.RegularStudyZOLoadSubjects");
            DropForeignKey("dbo.GroupRegularStudyZOLoadSubjects", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "Teacher_Id", "dbo.TeacherModels");
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.GroupRegularStudyZOLoadSubjects", new[] { "RegularStudyZOLoadSubjectsId" });
            DropIndex("dbo.GroupRegularStudyZOLoadSubjects", new[] { "GroupId" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "ZOLoadRegular_Id" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "Subject_Id" });
            DropTable("dbo.GroupRegularStudyZOLoadSubjects");
            DropTable("dbo.ZOLoadRegulars");
            DropTable("dbo.RegularStudyZOLoadSubjects");
        }
    }
}
