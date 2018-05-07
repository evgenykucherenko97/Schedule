namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegularStudyDayLoadGEKs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdLoad = c.Guid(),
                        MyProperty = c.Int(nullable: false),
                        LoadName = c.String(),
                        StudentCount = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        Cons = c.Double(),
                        GraduatingBaschelorWork = c.Double(),
                        DP = c.Double(),
                        ProizvPractice = c.Double(),
                        PreDiplomPractice = c.Double(),
                        Magistr = c.Double(),
                        Aspir = c.Double(),
                        GEK = c.Double(),
                        AllCredits = c.Double(nullable: false),
                        Load_Id = c.Guid(),
                        Subject_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DayLoadRegulars", t => t.Load_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.TeacherModels", t => t.Teacher_Id)
                .Index(t => t.Load_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.RegularStudyDayLoadSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadId = c.Guid(),
                        StudentCount = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        KindOfClasses = c.Int(nullable: false),
                        HoursOfWork = c.Double(),
                        HoursOfWorkAll = c.Double(),
                        FormOfControl = c.Int(nullable: false),
                        HoursForControl = c.Double(),
                        DZ = c.Double(),
                        CourseWork = c.Int(nullable: false),
                        HoursForCourseWork = c.Double(),
                        Cons = c.Double(),
                        AllCredits = c.Double(nullable: false),
                        SelfWorkHours = c.Double(nullable: false),
                        IsFRL = c.Boolean(nullable: false),
                        Subject_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                        DayLoadRegular_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.TeacherModels", t => t.Teacher_Id)
                .ForeignKey("dbo.DayLoadRegulars", t => t.DayLoadRegular_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.DayLoadRegular_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.GroupRegularStudyDayLoadGEK",
                c => new
                    {
                        GroupId = c.Guid(nullable: false),
                        RegularStudyDayLoadGEKId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RegularStudyDayLoadGEKId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.RegularStudyDayLoadGEKs", t => t.RegularStudyDayLoadGEKId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RegularStudyDayLoadGEKId);
            
            CreateTable(
                "dbo.GroupRegularStudyDayLoadSubjects",
                c => new
                    {
                        GroupId = c.Guid(nullable: false),
                        RegularStudyDayLoadSubjectsId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RegularStudyDayLoadSubjectsId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.RegularStudyDayLoadSubjects", t => t.RegularStudyDayLoadSubjectsId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RegularStudyDayLoadSubjectsId);
            
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
            
            AddColumn("dbo.FileModels", "DayLoadRegular_Id", c => c.Guid());
            CreateIndex("dbo.FileModels", "DayLoadRegular_Id");
            AddForeignKey("dbo.FileModels", "DayLoadRegular_Id", "dbo.DayLoadRegulars", "Id");
            DropTable("dbo.DayLoadDTOes");
            DropTable("dbo.ZOLoadDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZOLoadDTOes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectName = c.String(),
                        Grade = c.Int(nullable: false),
                        GroupCount = c.Int(nullable: false),
                        StudentCount = c.Int(nullable: false),
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
                        HoursForCourseWork = c.Double(),
                        Cons = c.Double(),
                        ConsAll = c.Double(),
                        ExamHours = c.Double(),
                        DivHours = c.Double(),
                        AllHours = c.Double(),
                        TeacherName = c.String(),
                        PartOfYear = c.String(),
                        Npr = c.Double(nullable: false),
                        CreditsECTS = c.Double(nullable: false),
                        SelfWorkHours = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DayLoadDTOes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoadId = c.Guid(),
                        SubjectName = c.String(),
                        Grade = c.Int(nullable: false),
                        GroupCount = c.Int(nullable: false),
                        StudentCount = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        DZ = c.Double(),
                        HoursOfLections = c.Double(),
                        HoursOfLabWork = c.Double(),
                        HoursOfLabWorkAll = c.Double(),
                        HoursOfPractWork = c.Double(),
                        HoursOfPractWorkAll = c.Double(),
                        KP_KR = c.Double(),
                        Cons = c.Double(),
                        ExamHours = c.Double(),
                        DivHours = c.Double(),
                        GraduatingBaschelorWork = c.Double(),
                        DP = c.Double(),
                        ProizvPractice = c.Double(),
                        PreDiplomPractice = c.Double(),
                        Magistr = c.Double(),
                        Aspir = c.Double(),
                        GEK = c.Double(),
                        SelfWork = c.Double(),
                        AllHours = c.Double(),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "ZOLoadRegular_Id", "dbo.ZOLoadRegulars");
            DropForeignKey("dbo.RegularStudyDayLoadSubjects", "DayLoadRegular_Id", "dbo.DayLoadRegulars");
            DropForeignKey("dbo.RegularStudyDayLoadGEKs", "Teacher_Id", "dbo.TeacherModels");
            DropForeignKey("dbo.RegularStudyDayLoadGEKs", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.RegularStudyDayLoadGEKs", "Load_Id", "dbo.DayLoadRegulars");
            DropForeignKey("dbo.GroupRegularStudyZOLoadSubjects", "RegularStudyZOLoadSubjectsId", "dbo.RegularStudyZOLoadSubjects");
            DropForeignKey("dbo.GroupRegularStudyZOLoadSubjects", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "Teacher_Id", "dbo.TeacherModels");
            DropForeignKey("dbo.RegularStudyZOLoadSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.GroupRegularStudyDayLoadSubjects", "RegularStudyDayLoadSubjectsId", "dbo.RegularStudyDayLoadSubjects");
            DropForeignKey("dbo.GroupRegularStudyDayLoadSubjects", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.RegularStudyDayLoadSubjects", "Teacher_Id", "dbo.TeacherModels");
            DropForeignKey("dbo.RegularStudyDayLoadSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.GroupRegularStudyDayLoadGEK", "RegularStudyDayLoadGEKId", "dbo.RegularStudyDayLoadGEKs");
            DropForeignKey("dbo.GroupRegularStudyDayLoadGEK", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.FileModels", "DayLoadRegular_Id", "dbo.DayLoadRegulars");
            DropIndex("dbo.GroupRegularStudyZOLoadSubjects", new[] { "RegularStudyZOLoadSubjectsId" });
            DropIndex("dbo.GroupRegularStudyZOLoadSubjects", new[] { "GroupId" });
            DropIndex("dbo.GroupRegularStudyDayLoadSubjects", new[] { "RegularStudyDayLoadSubjectsId" });
            DropIndex("dbo.GroupRegularStudyDayLoadSubjects", new[] { "GroupId" });
            DropIndex("dbo.GroupRegularStudyDayLoadGEK", new[] { "RegularStudyDayLoadGEKId" });
            DropIndex("dbo.GroupRegularStudyDayLoadGEK", new[] { "GroupId" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "ZOLoadRegular_Id" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.RegularStudyZOLoadSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.RegularStudyDayLoadSubjects", new[] { "DayLoadRegular_Id" });
            DropIndex("dbo.RegularStudyDayLoadSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.RegularStudyDayLoadSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.RegularStudyDayLoadGEKs", new[] { "Teacher_Id" });
            DropIndex("dbo.RegularStudyDayLoadGEKs", new[] { "Subject_Id" });
            DropIndex("dbo.RegularStudyDayLoadGEKs", new[] { "Load_Id" });
            DropIndex("dbo.FileModels", new[] { "DayLoadRegular_Id" });
            DropColumn("dbo.FileModels", "DayLoadRegular_Id");
            DropTable("dbo.GroupRegularStudyZOLoadSubjects");
            DropTable("dbo.GroupRegularStudyDayLoadSubjects");
            DropTable("dbo.GroupRegularStudyDayLoadGEK");
            DropTable("dbo.ZOLoadRegulars");
            DropTable("dbo.RegularStudyZOLoadSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.RegularStudyDayLoadSubjects");
            DropTable("dbo.RegularStudyDayLoadGEKs");
        }
    }
}
