namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateCreatedClosedColumnsToTicketTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "DateClosed");
            DropColumn("dbo.Tickets", "DateCreated");
        }
    }
}
