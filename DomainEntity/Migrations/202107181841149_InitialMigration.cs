namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(nullable: false, maxLength: 200),
                        Length = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Thickness = c.Int(nullable: false),
                        PanelSurface = c.Double(nullable: false),
                        CurrentPanelSurface = c.Double(nullable: false),
                        CurrentNumberOfPanel = c.Int(nullable: false),
                        PanelType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Texture = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materials");
        }
    }
}
