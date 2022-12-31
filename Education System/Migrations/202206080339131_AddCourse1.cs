﻿namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Description");
        }
    }
}
