namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventFLowDetailDeletedForNowTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventFlowTable", "FlowTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventFlowTable", "FlowTime", c => c.DateTime(nullable: false));
        }
    }
}
