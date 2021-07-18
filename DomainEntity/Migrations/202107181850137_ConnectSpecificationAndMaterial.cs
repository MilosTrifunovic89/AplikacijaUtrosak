namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectSpecificationAndMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificationMaterials",
                c => new
                    {
                        MaterialID = c.Int(nullable: false),
                        SpecificationID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialID, t.SpecificationID })
                .ForeignKey("dbo.Materials", t => t.MaterialID)
                .ForeignKey("dbo.Specifications", t => t.SpecificationID)
                .Index(t => t.MaterialID)
                .Index(t => t.SpecificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecificationMaterials", "SpecificationID", "dbo.Specifications");
            DropForeignKey("dbo.SpecificationMaterials", "MaterialID", "dbo.Materials");
            DropIndex("dbo.SpecificationMaterials", new[] { "SpecificationID" });
            DropIndex("dbo.SpecificationMaterials", new[] { "MaterialID" });
            DropTable("dbo.SpecificationMaterials");
        }
    }
}
