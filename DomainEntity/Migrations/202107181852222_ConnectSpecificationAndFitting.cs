namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectSpecificationAndFitting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationFittings",
                c => new
                    {
                        FittingID = c.Int(nullable: false),
                        SpecificationID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FittingID, t.SpecificationID })
                .ForeignKey("dbo.Fittings", t => t.FittingID)
                .ForeignKey("dbo.Specifications", t => t.SpecificationID)
                .Index(t => t.FittingID)
                .Index(t => t.SpecificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationFittings", "SpecificationID", "dbo.Specifications");
            DropForeignKey("dbo.SpecificationFittings", "FittingID", "dbo.Fittings");
            DropIndex("dbo.SpecificationFittings", new[] { "SpecificationID" });
            DropIndex("dbo.SpecificationFittings", new[] { "FittingID" });
            DropTable("dbo.SpecificationFittings");
        }
    }
}
