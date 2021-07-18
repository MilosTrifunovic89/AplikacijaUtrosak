namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEdgeTapeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EdgeTapes",
                c => new
                    {
                        EdgeTapeId = c.Int(nullable: false, identity: true),
                        EdgeTapeName = c.String(nullable: false, maxLength: 200),
                        Width = c.Int(nullable: false),
                        Thickness = c.Double(nullable: false),
                        EdgeTapeType = c.Int(nullable: false),
                        CurrentState = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EdgeTapeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EdgeTapes");
        }
    }
}
