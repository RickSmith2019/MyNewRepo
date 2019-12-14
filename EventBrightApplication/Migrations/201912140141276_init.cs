namespace EventBrightApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        OrganizerName = c.String(nullable: false),
                        OrganizerInfo = c.String(),
                        MaxTickets = c.Int(nullable: false),
                        AvailableTickets = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        TypeId_TypeId = c.Int(),
                        TypeName_TypeId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventTypes", t => t.TypeId_TypeId)
                .ForeignKey("dbo.EventTypes", t => t.TypeName_TypeId)
                .Index(t => t.TypeId_TypeId)
                .Index(t => t.TypeName_TypeId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 50),
                        TypeDescription = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderNumber = c.Int(nullable: false, identity: true),
                        OrderId = c.String(),
                        NumberOfTickets = c.Int(nullable: false),
                        DateOrdered = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderNumber)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "TypeName_TypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "TypeId_TypeId", "dbo.EventTypes");
            DropIndex("dbo.Orders", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "TypeName_TypeId" });
            DropIndex("dbo.Events", new[] { "TypeId_TypeId" });
            DropTable("dbo.Orders");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
