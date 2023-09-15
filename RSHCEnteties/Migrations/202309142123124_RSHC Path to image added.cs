namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RSHCPathtoimageadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RSHCDevices", "PathToImage", c => c.String());
            AddColumn("dbo.RSHCEmployees", "PathToImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RSHCEmployees", "PathToImage");
            DropColumn("dbo.RSHCDevices", "PathToImage");
        }
    }
}
