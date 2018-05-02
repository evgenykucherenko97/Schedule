namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayLoadRegularMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DayLoadRegulars", "LoadName", c => c.String());
            AddColumn("dbo.DayLoadRegulars", "LoadKind", c => c.Int(nullable: false));
            AddColumn("dbo.DayLoadRegulars", "StudentKind", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DayLoadRegulars", "StudentKind");
            DropColumn("dbo.DayLoadRegulars", "LoadKind");
            DropColumn("dbo.DayLoadRegulars", "LoadName");
        }
    }
}
