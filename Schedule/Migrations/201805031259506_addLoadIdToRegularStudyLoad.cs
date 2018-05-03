namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLoadIdToRegularStudyLoad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularStudyDayLoadSubjects", "LoadId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularStudyDayLoadSubjects", "LoadId");
        }
    }
}
