namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileModels", "DayLoadRegular_Id", "dbo.DayLoadRegulars");
            DropIndex("dbo.FileModels", new[] { "DayLoadRegular_Id" });
            AddColumn("dbo.RegularStudyDayLoadGEKs", "ZOLoadRegular_Id", c => c.Guid());
            CreateIndex("dbo.RegularStudyDayLoadGEKs", "ZOLoadRegular_Id");
            AddForeignKey("dbo.RegularStudyDayLoadGEKs", "ZOLoadRegular_Id", "dbo.ZOLoadRegulars", "Id");
            DropColumn("dbo.DayLoadRegulars", "LoadKind");
            DropColumn("dbo.FileModels", "DayLoadRegular_Id");
            DropColumn("dbo.ZOLoadRegulars", "LoadKind");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZOLoadRegulars", "LoadKind", c => c.Int(nullable: false));
            AddColumn("dbo.FileModels", "DayLoadRegular_Id", c => c.Guid());
            AddColumn("dbo.DayLoadRegulars", "LoadKind", c => c.Int(nullable: false));
            DropForeignKey("dbo.RegularStudyDayLoadGEKs", "ZOLoadRegular_Id", "dbo.ZOLoadRegulars");
            DropIndex("dbo.RegularStudyDayLoadGEKs", new[] { "ZOLoadRegular_Id" });
            DropColumn("dbo.RegularStudyDayLoadGEKs", "ZOLoadRegular_Id");
            CreateIndex("dbo.FileModels", "DayLoadRegular_Id");
            AddForeignKey("dbo.FileModels", "DayLoadRegular_Id", "dbo.DayLoadRegulars", "Id");
        }
    }
}
