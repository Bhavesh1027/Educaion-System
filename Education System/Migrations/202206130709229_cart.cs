namespace Education_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.carts",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        image = c.String(),
                        qty = c.Int(),
                        bil = c.Int(),
                        Cemail = c.String(),
                        price = c.Int(),
                    })
                .PrimaryKey(t => t.Cid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.carts");
        }
    }
}
