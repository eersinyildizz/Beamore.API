namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventTable", "EventStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EventTable", "EventFinishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.EventTable", "EventDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventTable", "EventDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.EventTable", "EventFinishDate");
            DropColumn("dbo.EventTable", "EventStartDate");
        }
    }
}
