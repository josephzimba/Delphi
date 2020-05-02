namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDatesNullableInTicketsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateCreated", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DateClosed", c => c.DateTime(nullable: false));
        }
    }
}
