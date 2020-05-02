namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTicketTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (1, 'Add Contract')");
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (2, 'Update Contract')");
            Sql("INSERT INTO TicketTypes (Id, Name) VALUES (3, 'Terminate Contract')");
        }
        
        public override void Down()
        {
        }
    }
}
