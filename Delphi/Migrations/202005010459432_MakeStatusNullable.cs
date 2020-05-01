namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeStatusNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Status", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Status", c => c.String(nullable: false));
        }
    }
}
