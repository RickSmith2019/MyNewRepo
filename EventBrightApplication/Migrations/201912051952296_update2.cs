namespace EventBrightApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "TypeName_TypeId", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "TypeId_TypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "TypeId_TypeId" });
            DropIndex("dbo.Events", new[] { "TypeName_TypeId" });
            RenameColumn(table: "dbo.Events", name: "TypeId_TypeId", newName: "TypeId");
            AlterColumn("dbo.Events", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "TypeId");
            AddForeignKey("dbo.Events", "TypeId", "dbo.EventTypes", "TypeId", cascadeDelete: true);
            DropColumn("dbo.Events", "TypeName_TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TypeName_TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "TypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "TypeId" });
            AlterColumn("dbo.Events", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "TypeId", newName: "TypeId_TypeId");
            CreateIndex("dbo.Events", "TypeName_TypeId");
            CreateIndex("dbo.Events", "TypeId_TypeId");
            AddForeignKey("dbo.Events", "TypeId_TypeId", "dbo.EventTypes", "TypeId");
            AddForeignKey("dbo.Events", "TypeName_TypeId", "dbo.EventTypes", "TypeId", cascadeDelete: true);
        }
    }
}
