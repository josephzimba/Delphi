namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clients", "StatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Clients", "StatusId");
            AddForeignKey("dbo.Clients", "StatusId", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "StatusId", "dbo.Status");
            DropIndex("dbo.Clients", new[] { "StatusId" });
            DropColumn("dbo.Clients", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
