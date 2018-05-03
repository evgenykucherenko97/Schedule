namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "RegularStudyDayLoadSubjects_Id", "dbo.RegularStudyDayLoadSubjects");
            DropIndex("dbo.Groups", new[] { "RegularStudyDayLoadSubjects_Id" });
            CreateTable(
                "dbo.GroupRegularStudyDayLoadSubjects",
                c => new
                    {
                        RegularStudyDayLoadSubjectsId = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegularStudyDayLoadSubjectsId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.RegularStudyDayLoadSubjects", t => t.RegularStudyDayLoadSubjectsId, cascadeDelete: true)
                .Index(t => t.RegularStudyDayLoadSubjectsId)
                .Index(t => t.GroupId);
            
            DropColumn("dbo.Groups", "RegularStudyDayLoadSubjects_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "RegularStudyDayLoadSubjects_Id", c => c.Guid());
            DropForeignKey("dbo.GroupRegularStudyDayLoadSubjects", "GroupId", "dbo.RegularStudyDayLoadSubjects");
            DropForeignKey("dbo.GroupRegularStudyDayLoadSubjects", "RegularStudyDayLoadSubjectsId", "dbo.Groups");
            DropIndex("dbo.GroupRegularStudyDayLoadSubjects", new[] { "GroupId" });
            DropIndex("dbo.GroupRegularStudyDayLoadSubjects", new[] { "RegularStudyDayLoadSubjectsId" });
            DropTable("dbo.GroupRegularStudyDayLoadSubjects");
            CreateIndex("dbo.Groups", "RegularStudyDayLoadSubjects_Id");
            AddForeignKey("dbo.Groups", "RegularStudyDayLoadSubjects_Id", "dbo.RegularStudyDayLoadSubjects", "Id");
        }
    }
}
