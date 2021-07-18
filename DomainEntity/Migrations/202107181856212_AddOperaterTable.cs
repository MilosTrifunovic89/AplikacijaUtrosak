namespace DomainEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOperaterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operaters",
                c => new
                    {
                        OperaterID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.OperaterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Operaters");
        }
    }
}
