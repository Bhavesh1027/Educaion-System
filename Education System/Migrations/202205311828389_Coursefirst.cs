namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coursefirst : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Courses");
            AddColumn("dbo.Courses", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AddPrimaryKey("dbo.Courses", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Courses", "id");
            AddPrimaryKey("dbo.Courses", "Name");
        }
    }
}
