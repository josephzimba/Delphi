namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientAndStaffTablesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        SIN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
            DropTable("dbo.Clients");
        }
    }
}
