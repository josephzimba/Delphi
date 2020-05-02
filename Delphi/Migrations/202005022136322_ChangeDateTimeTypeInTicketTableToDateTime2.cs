namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeTypeInTicketTableToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateCreated", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Tickets", "DateCreated", c => c.DateTime(nullable: true));
        }
    }
}
