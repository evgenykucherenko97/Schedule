namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZOLoadDTOMigration : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZOLoadDTOes");
        }
    }
}
