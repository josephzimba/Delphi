namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractPriceToTicketTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ContractPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "ContractPrice");
        }
    }
}
