namespace Entity_Framework_Form_7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Airplane_type = c.String(),
                        Airplane_class = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Customs_Formalities = c.Boolean(nullable: false),
                        BankCard = c.String(),
                        DateValidicity = c.DateTime(nullable: false),
                        CVV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteID = c.Int(),
                        CustomerID = c.Int(),
                        AirplaneID = c.Int(),
                        Price = c.Int(nullable: false),
                        NumberOfPassenger = c.Int(nullable: false),
                        Seat = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airplanes", t => t.AirplaneID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Waybills", t => t.RouteID)
                .Index(t => t.RouteID)
                .Index(t => t.CustomerID)
                .Index(t => t.AirplaneID);
            
            CreateTable(
                "dbo.Waybills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DispatchCountry = c.String(),
                        ArrivalCountry = c.String(),
                        IsDifferentCountry = c.Boolean(),
                        DispatchCity = c.String(),
                        ArrivalCity = c.String(),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "RouteID", "dbo.Waybills");
            DropForeignKey("dbo.Tickets", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Tickets", "AirplaneID", "dbo.Airplanes");
            DropIndex("dbo.Tickets", new[] { "AirplaneID" });
            DropIndex("dbo.Tickets", new[] { "CustomerID" });
            DropIndex("dbo.Tickets", new[] { "RouteID" });
            DropTable("dbo.Waybills");
            DropTable("dbo.Tickets");
            DropTable("dbo.Customers");
            DropTable("dbo.Airplanes");
        }
    }
}
