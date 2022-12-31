namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Course_Details", c => c.String());
            AddColumn("dbo.Courses", "Requirements", c => c.String());
            AddColumn("dbo.Courses", "Course_Syllabus", c => c.String());
            AddColumn("dbo.Courses", "Credits", c => c.String());
            DropColumn("dbo.Courses", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
            DropColumn("dbo.Courses", "Credits");
            DropColumn("dbo.Courses", "Course_Syllabus");
            DropColumn("dbo.Courses", "Requirements");
            DropColumn("dbo.Courses", "Course_Details");
        }
    }
}
