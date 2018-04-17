namespace Schedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Faculty = c.String(),
                        Caf = c.String(),
                        Speciality = c.String(),
                        Grade = c.Int(nullable: false),
                        StudentCount = c.Int(),
                        GroupKind = c.Int(nullable: false),
                        GroupClassesKind = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Groups");
        }
    }
}
