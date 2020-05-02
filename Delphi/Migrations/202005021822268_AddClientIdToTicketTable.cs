namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientIdToTicketTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "ClientId");
            AddForeignKey("dbo.Tickets", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ClientId", "dbo.Clients");
            DropIndex("dbo.Tickets", new[] { "ClientId" });
            DropColumn("dbo.Tickets", "ClientId");
        }
    }
}
