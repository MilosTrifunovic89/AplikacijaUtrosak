namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFittingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fittings",
                c => new
                    {
                        FittingsId = c.Int(nullable: false, identity: true),
                        FittingName = c.String(nullable: false, maxLength: 200),
                        UnitMeasure = c.String(nullable: false, maxLength: 10),
                        CurrentState = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FittingsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fittings");
        }
    }
}
