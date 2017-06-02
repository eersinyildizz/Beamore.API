namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventStrtTimeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventTable", "EventStartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventTable", "EventStartTime");
        }
    }
}
