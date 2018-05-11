namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RegularStudyDayLoadGEKs", name: "Load_Id", newName: "DayLoadRegular_Id");
            RenameIndex(table: "dbo.RegularStudyDayLoadGEKs", name: "IX_Load_Id", newName: "IX_DayLoadRegular_Id");
            AddColumn("dbo.RegularStudyDayLoadGEKs", "GroupCount", c => c.Int(nullable: false));
            AddColumn("dbo.RegularStudyDayLoadGEKs", "GEK_Work", c => c.Int(nullable: false));
            AddColumn("dbo.RegularStudyDayLoadGEKs", "HoursForWork", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "Npr", c => c.Double());
            DropColumn("dbo.RegularStudyDayLoadGEKs", "MyProperty");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "LoadName");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "Cons");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "GraduatingBaschelorWork");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "DP");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "ProizvPractice");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "PreDiplomPractice");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "Magistr");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "Aspir");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "GEK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularStudyDayLoadGEKs", "GEK", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "Aspir", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "Magistr", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "PreDiplomPractice", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "ProizvPractice", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "DP", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "GraduatingBaschelorWork", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "Cons", c => c.Double());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "LoadName", c => c.String());
            AddColumn("dbo.RegularStudyDayLoadGEKs", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.RegularStudyDayLoadGEKs", "Npr");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "HoursForWork");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "GEK_Work");
            DropColumn("dbo.RegularStudyDayLoadGEKs", "GroupCount");
            RenameIndex(table: "dbo.RegularStudyDayLoadGEKs", name: "IX_DayLoadRegular_Id", newName: "IX_Load_Id");
            RenameColumn(table: "dbo.RegularStudyDayLoadGEKs", name: "DayLoadRegular_Id", newName: "Load_Id");
        }
    }
}
