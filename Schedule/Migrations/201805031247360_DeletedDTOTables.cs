namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedDTOTables : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
