namespace Delphi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOccupationColumnToStaffTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Occupation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Occupation");
        }
    }
}
