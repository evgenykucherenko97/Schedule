namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnLoadIdToDayLoadDTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DayLoadDTOes", "LoadId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DayLoadDTOes", "LoadId");
        }
    }
}
