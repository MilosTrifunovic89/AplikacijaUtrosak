namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        SpecificationId = c.Int(nullable: false, identity: true),
                        SpecificationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SpecificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specifications");
        }
    }
}
