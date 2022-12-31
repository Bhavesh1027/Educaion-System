namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Duration = c.String(),
                        Lessons = c.String(),
                        seats = c.String(),
                        Image = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
