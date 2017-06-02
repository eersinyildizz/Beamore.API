namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventFLowDetailDeletedForNow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventFlowTable", "Header", c => c.String());
            AddColumn("dbo.EventFlowTable", "Explain", c => c.String());
            AddColumn("dbo.EventFlowTable", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventFlowTable", "CompanyName");
            DropColumn("dbo.EventFlowTable", "Explain");
            DropColumn("dbo.EventFlowTable", "Header");
        }
    }
}
