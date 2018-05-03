namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyTo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "RegularStudyDayLoadGEKId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "GroupId", newName: "RegularStudyDayLoadGEKId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "RegularStudyDayLoadSubjectsId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "GroupId", newName: "RegularStudyDayLoadSubjectsId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "__mig_tmp__0", newName: "GroupId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "__mig_tmp__1", newName: "GroupId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "IX_RegularStudyDayLoadGEKId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "IX_GroupId", newName: "IX_RegularStudyDayLoadGEKId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "IX_RegularStudyDayLoadSubjectsId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "IX_GroupId", newName: "IX_RegularStudyDayLoadSubjectsId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "__mig_tmp__0", newName: "IX_GroupId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "__mig_tmp__1", newName: "IX_GroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "IX_GroupId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "IX_GroupId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "IX_RegularStudyDayLoadSubjectsId", newName: "IX_GroupId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "__mig_tmp__1", newName: "IX_RegularStudyDayLoadSubjectsId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "IX_RegularStudyDayLoadGEKId", newName: "IX_GroupId");
            RenameIndex(table: "dbo.GroupRegularStudyDayLoadGEK", name: "__mig_tmp__0", newName: "IX_RegularStudyDayLoadGEKId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "GroupId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "GroupId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "RegularStudyDayLoadSubjectsId", newName: "GroupId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadSubjects", name: "__mig_tmp__1", newName: "RegularStudyDayLoadSubjectsId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "RegularStudyDayLoadGEKId", newName: "GroupId");
            RenameColumn(table: "dbo.GroupRegularStudyDayLoadGEK", name: "__mig_tmp__0", newName: "RegularStudyDayLoadGEKId");
        }
    }
}
