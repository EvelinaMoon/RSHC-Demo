namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22092023AddedDeviceName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RSHCDevices", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RSHCEmployees", "UserID", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.RSHCOffBoardings", "OffBoardingStarted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RSHCOnBoardings", "OnBoardingStarted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RSHCOnBoardings", "OnBoardingStarted", c => c.DateTime());
            AlterColumn("dbo.RSHCOffBoardings", "OffBoardingStarted", c => c.DateTime());
            AlterColumn("dbo.RSHCEmployees", "UserID", c => c.String(maxLength: 255));
            DropColumn("dbo.RSHCDevices", "Name");
        }
    }
}
