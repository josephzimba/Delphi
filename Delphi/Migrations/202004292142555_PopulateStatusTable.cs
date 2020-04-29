namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatusTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Status (Name) VALUES ('Active')");
            Sql("INSERT INTO Status (Name) VALUES ('Terminated')");
            Sql("INSERT INTO Status (Name) VALUES ('Pending')");
            Sql("INSERT INTO Status (Name) VALUES ('Suspended')");
        }
        
        public override void Down()
        {
        }
    }
}
