namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventParticipantNumberAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventDetailTable", "Participant", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventDetailTable", "Participant");
        }
    }
}
