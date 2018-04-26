namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayLoadDTOMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayLoadDTOes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
        
        public override void Down()
        {
            DropTable("dbo.DayLoadDTOes");
        }
    }
}
