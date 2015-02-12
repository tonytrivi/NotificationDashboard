namespace NotificationDashboardPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        ServerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LocationLatLong = c.Geography(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.ServerId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.StatusNotifications",
                c => new
                    {
                        StatusNotificationId = c.Int(nullable: false, identity: true),
                        StatusType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Message = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ITManagerId = c.Int(nullable: false),
                        ServerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusNotificationId)
                .ForeignKey("dbo.ITManagers", t => t.ITManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.ServerId, cascadeDelete: true)
                .Index(t => t.ITManagerId)
                .Index(t => t.ServerId);
            
            CreateTable(
                "dbo.ITManagers",
                c => new
                    {
                        ITManagerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ITCompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ITManagerId)
                .ForeignKey("dbo.ITCompanies", t => t.ITCompanyId, cascadeDelete: true)
                .Index(t => t.ITCompanyId);
            
            CreateTable(
                "dbo.ITCompanies",
                c => new
                    {
                        ITCompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ITCompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.StatusNotifications", "ServerId", "dbo.Servers");
            DropForeignKey("dbo.StatusNotifications", "ITManagerId", "dbo.ITManagers");
            DropForeignKey("dbo.ITManagers", "ITCompanyId", "dbo.ITCompanies");
            DropIndex("dbo.ITManagers", new[] { "ITCompanyId" });
            DropIndex("dbo.StatusNotifications", new[] { "ServerId" });
            DropIndex("dbo.StatusNotifications", new[] { "ITManagerId" });
            DropIndex("dbo.Servers", new[] { "Customer_CustomerId" });
            DropTable("dbo.ITCompanies");
            DropTable("dbo.ITManagers");
            DropTable("dbo.StatusNotifications");
            DropTable("dbo.Servers");
            DropTable("dbo.Customers");
        }
    }
}
