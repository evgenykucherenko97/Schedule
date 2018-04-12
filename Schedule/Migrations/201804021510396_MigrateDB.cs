namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SecondName = c.String(),
                        Surname = c.String(),
                        IdDegree = c.Guid(),
                        IdPosition = c.Guid(),
                        Degree_Id = c.Guid(),
                        Position_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.Degree_Id)
                .ForeignKey("dbo.PositionModels", t => t.Position_Id)
                .Index(t => t.Degree_Id)
                .Index(t => t.Position_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TeacherModels", "Position_Id", "dbo.PositionModels");
            DropForeignKey("dbo.TeacherModels", "Degree_Id", "dbo.Degrees");
            DropIndex("dbo.TeacherModels", new[] { "Position_Id" });
            DropIndex("dbo.TeacherModels", new[] { "Degree_Id" });
            DropTable("dbo.TeacherModels");
        }
    }
}
