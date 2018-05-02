namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoadDayRegularMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayLoadRegulars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DayLoadRegulars");
        }
    }
}
