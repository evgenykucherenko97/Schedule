namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRegularDayLoadModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RegularStudyDayLoadSubjects", "IdLoad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularStudyDayLoadSubjects", "IdLoad", c => c.Guid());
        }
    }
}
