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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clients", "StatusId", c => c.Byte(nullable: false));
            AddColumn("dbo.Clients", "Status_Id", c => c.Int());
            CreateIndex("dbo.Clients", "Status_Id");
            AddForeignKey("dbo.Clients", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Status_Id", "dbo.Status");
            DropIndex("dbo.Clients", new[] { "Status_Id" });
            DropColumn("dbo.Clients", "Status_Id");
            DropColumn("dbo.Clients", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
