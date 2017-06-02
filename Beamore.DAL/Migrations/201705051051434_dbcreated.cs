namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeaconChatTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderType = c.Int(nullable: false),
                        Message = c.String(),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BeaconId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeaconTable", t => t.BeaconId, cascadeDelete: true)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId)
                .Index(t => t.BeaconId);
            
            CreateTable(    
                "dbo.BeaconTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeaconUniqueId = c.String(),
                        Password = c.String(),
                        UsedDate = c.DateTime(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: false)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.BeaconNoteTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteHeader = c.String(),
                        Note = c.String(),
                        SentDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BeaconId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeaconTable", t => t.BeaconId, cascadeDelete: true)
                .Index(t => t.BeaconId);
            
            CreateTable(
                "dbo.EventTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventEmail = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LogoUrl = c.String(),
                        LocationId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryTable", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.LocationTable", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CategoryTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryExplanation = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventDetailTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventExplanation = c.String(),
                        Tag = c.String(),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventFlowTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowTime = c.DateTime(nullable: false),
                        FlowName = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        SubEvent = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventFlowDetailTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Explain = c.String(),
                        CompanyName = c.String(),
                        EventFlowId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventFlowTable", t => t.EventFlowId, cascadeDelete: true)
                .Index(t => t.EventFlowId);
            
            CreateTable(
                "dbo.EventSubcriberTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Address = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserMobileDeviceTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueDeviceId = c.Int(nullable: false),
                        PushNotificationIdentifier = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SentNotificationTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationHeader = c.String(),
                        NotificationMessage = c.String(),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.SurveyTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        BeaconId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeaconTable", t => t.BeaconId, cascadeDelete: true)
                .ForeignKey("dbo.EventTable", t => t.EventId, cascadeDelete: true)
                .Index(t => t.BeaconId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.SurvayOptionTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        NumberOfSelected = c.Int(nullable: false),
                        SurvayId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyTable", t => t.SurvayId, cascadeDelete: true)
                .Index(t => t.SurvayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurvayOptionTable", "SurvayId", "dbo.SurveyTable");
            DropForeignKey("dbo.SurveyTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.SurveyTable", "BeaconId", "dbo.BeaconTable");
            DropForeignKey("dbo.SentNotificationTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.UserMobileDeviceTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.LocationTable", "User_Id", "dbo.UserTable");
            DropForeignKey("dbo.EventTable", "LocationId", "dbo.LocationTable");
            DropForeignKey("dbo.EventSubcriberTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.EventTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.BeaconTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.BeaconChatTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.EventSubcriberTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.EventFlowTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.EventFlowDetailTable", "EventFlowId", "dbo.EventFlowTable");
            DropForeignKey("dbo.EventDetailTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.EventTable", "CategoryId", "dbo.CategoryTable");
            DropForeignKey("dbo.BeaconTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.BeaconChatTable", "EventId", "dbo.EventTable");
            DropForeignKey("dbo.BeaconNoteTable", "BeaconId", "dbo.BeaconTable");
            DropForeignKey("dbo.BeaconChatTable", "BeaconId", "dbo.BeaconTable");
            DropIndex("dbo.SurvayOptionTable", new[] { "SurvayId" });
            DropIndex("dbo.SurveyTable", new[] { "EventId" });
            DropIndex("dbo.SurveyTable", new[] { "BeaconId" });
            DropIndex("dbo.SentNotificationTable", new[] { "EventId" });
            DropIndex("dbo.UserMobileDeviceTable", new[] { "UserId" });
            DropIndex("dbo.LocationTable", new[] { "User_Id" });
            DropIndex("dbo.EventSubcriberTable", new[] { "UserId" });
            DropIndex("dbo.EventSubcriberTable", new[] { "EventId" });
            DropIndex("dbo.EventFlowDetailTable", new[] { "EventFlowId" });
            DropIndex("dbo.EventFlowTable", new[] { "EventId" });
            DropIndex("dbo.EventDetailTable", new[] { "EventId" });
            DropIndex("dbo.EventTable", new[] { "CategoryId" });
            DropIndex("dbo.EventTable", new[] { "UserId" });
            DropIndex("dbo.EventTable", new[] { "LocationId" });
            DropIndex("dbo.BeaconNoteTable", new[] { "BeaconId" });
            DropIndex("dbo.BeaconTable", new[] { "EventId" });
            DropIndex("dbo.BeaconTable", new[] { "UserId" });
            DropIndex("dbo.BeaconChatTable", new[] { "BeaconId" });
            DropIndex("dbo.BeaconChatTable", new[] { "UserId" });
            DropIndex("dbo.BeaconChatTable", new[] { "EventId" });
            DropTable("dbo.SurvayOptionTable");
            DropTable("dbo.SurveyTable");
            DropTable("dbo.SentNotificationTable");
            DropTable("dbo.UserMobileDeviceTable");
            DropTable("dbo.LocationTable");
            DropTable("dbo.UserTable");
            DropTable("dbo.EventSubcriberTable");
            DropTable("dbo.EventFlowDetailTable");
            DropTable("dbo.EventFlowTable");
            DropTable("dbo.EventDetailTable");
            DropTable("dbo.CategoryTable");
            DropTable("dbo.EventTable");
            DropTable("dbo.BeaconNoteTable");
            DropTable("dbo.BeaconTable");
            DropTable("dbo.BeaconChatTable");
        }
    }
}
