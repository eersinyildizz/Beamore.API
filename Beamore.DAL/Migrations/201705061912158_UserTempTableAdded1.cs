namespace Beamore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTempTableAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempUserTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        TempGuid = c.String(),
                        ExpirationTime = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempUserTable");
        }
    }
}
