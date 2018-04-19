namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherModels", "Degree_Id", "dbo.Degrees");
            DropForeignKey("dbo.TeacherModels", "Position_Id", "dbo.PositionModels");
            DropIndex("dbo.TeacherModels", new[] { "Degree_Id" });
            DropIndex("dbo.TeacherModels", new[] { "Position_Id" });
            AlterColumn("dbo.Degrees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Faculty", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Caf", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "Speciality", c => c.String(nullable: false));
            AlterColumn("dbo.Groups", "StudentCount", c => c.Int(nullable: false));
            AlterColumn("dbo.PositionModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TeacherModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.TeacherModels", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.TeacherModels", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.TeacherModels", "Degree_Id", c => c.Guid(nullable: true)); //!!! null
            AlterColumn("dbo.TeacherModels", "Position_Id", c => c.Guid(nullable: true)); //!!! null
            CreateIndex("dbo.TeacherModels", "Degree_Id");
            CreateIndex("dbo.TeacherModels", "Position_Id");
            AddForeignKey("dbo.TeacherModels", "Degree_Id", "dbo.Degrees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherModels", "Position_Id", "dbo.PositionModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherModels", "Position_Id", "dbo.PositionModels");
            DropForeignKey("dbo.TeacherModels", "Degree_Id", "dbo.Degrees");
            DropIndex("dbo.TeacherModels", new[] { "Position_Id" });
            DropIndex("dbo.TeacherModels", new[] { "Degree_Id" });
            AlterColumn("dbo.TeacherModels", "Position_Id", c => c.Guid());
            AlterColumn("dbo.TeacherModels", "Degree_Id", c => c.Guid());
            AlterColumn("dbo.TeacherModels", "Surname", c => c.String());
            AlterColumn("dbo.TeacherModels", "SecondName", c => c.String());
            AlterColumn("dbo.TeacherModels", "Name", c => c.String());
            AlterColumn("dbo.PositionModels", "Name", c => c.String());
            AlterColumn("dbo.Groups", "StudentCount", c => c.Int());
            AlterColumn("dbo.Groups", "Speciality", c => c.String());
            AlterColumn("dbo.Groups", "Caf", c => c.String());
            AlterColumn("dbo.Groups", "Faculty", c => c.String());
            AlterColumn("dbo.Groups", "Name", c => c.String());
            AlterColumn("dbo.Degrees", "Name", c => c.String());
            CreateIndex("dbo.TeacherModels", "Position_Id");
            CreateIndex("dbo.TeacherModels", "Degree_Id");
            AddForeignKey("dbo.TeacherModels", "Position_Id", "dbo.PositionModels", "Id");
            AddForeignKey("dbo.TeacherModels", "Degree_Id", "dbo.Degrees", "Id");
        }
    }
}
