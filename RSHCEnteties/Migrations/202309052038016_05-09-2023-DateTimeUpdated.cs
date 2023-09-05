namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05092023DateTimeUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUsers", "AdmittedOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUsers", "AdmittedOut", c => c.DateTime(nullable: false));
        }
    }
}
