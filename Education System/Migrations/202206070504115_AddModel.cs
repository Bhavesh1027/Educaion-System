namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RegisterViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        Fname = c.String(nullable: false, maxLength: 15),
                        Lname = c.String(nullable: false, maxLength: 15),
                        PhoneNumber = c.String(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
    }
}
