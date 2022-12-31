namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Category");
        }
    }
}
