namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "RegularStudyDayLoadGEK_Id", "dbo.RegularStudyDayLoadGEKs");
            DropIndex("dbo.Groups", new[] { "RegularStudyDayLoadGEK_Id" });
            CreateTable(
                "dbo.GroupRegularStudyDayLoadGEK",
                c => new
                    {
                        RegularStudyDayLoadGEKId = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegularStudyDayLoadGEKId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.RegularStudyDayLoadGEKs", t => t.RegularStudyDayLoadGEKId, cascadeDelete: true)
                .Index(t => t.RegularStudyDayLoadGEKId)
                .Index(t => t.GroupId);
            
            DropColumn("dbo.Groups", "RegularStudyDayLoadGEK_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "RegularStudyDayLoadGEK_Id", c => c.Guid());
            DropForeignKey("dbo.GroupRegularStudyDayLoadGEK", "GroupId", "dbo.RegularStudyDayLoadGEKs");
            DropForeignKey("dbo.GroupRegularStudyDayLoadGEK", "RegularStudyDayLoadGEKId", "dbo.Groups");
            DropIndex("dbo.GroupRegularStudyDayLoadGEK", new[] { "GroupId" });
            DropIndex("dbo.GroupRegularStudyDayLoadGEK", new[] { "RegularStudyDayLoadGEKId" });
            DropTable("dbo.GroupRegularStudyDayLoadGEK");
            CreateIndex("dbo.Groups", "RegularStudyDayLoadGEK_Id");
            AddForeignKey("dbo.Groups", "RegularStudyDayLoadGEK_Id", "dbo.RegularStudyDayLoadGEKs", "Id");
        }
    }
}
