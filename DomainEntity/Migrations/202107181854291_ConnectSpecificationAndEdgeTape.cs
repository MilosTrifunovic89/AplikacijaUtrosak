namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectSpecificationAndEdgeTape : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationEdgeTapes",
                c => new
                    {
                        EdgeTapeID = c.Int(nullable: false),
                        SpecificationID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EdgeTapeID, t.SpecificationID })
                .ForeignKey("dbo.EdgeTapes", t => t.EdgeTapeID)
                .ForeignKey("dbo.Specifications", t => t.SpecificationID)
                .Index(t => t.EdgeTapeID)
                .Index(t => t.SpecificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationEdgeTapes", "SpecificationID", "dbo.Specifications");
            DropForeignKey("dbo.SpecificationEdgeTapes", "EdgeTapeID", "dbo.EdgeTapes");
            DropIndex("dbo.SpecificationEdgeTapes", new[] { "SpecificationID" });
            DropIndex("dbo.SpecificationEdgeTapes", new[] { "EdgeTapeID" });
            DropTable("dbo.SpecificationEdgeTapes");
        }
    }
}
