namespace Entity_Framework_Form_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManagerName = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManagerID = c.Int(),
                        CustomerID = c.Int(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Managers", t => t.ManagerID)
                .Index(t => t.ManagerID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ManagerID", "dbo.Managers");
            DropForeignKey("dbo.Users", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Users", new[] { "CustomerID" });
            DropIndex("dbo.Users", new[] { "ManagerID" });
            DropTable("dbo.Users");
            DropTable("dbo.Managers");
        }
    }
}
