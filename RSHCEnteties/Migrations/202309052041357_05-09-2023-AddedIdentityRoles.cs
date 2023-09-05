namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05092023AddedIdentityRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.IdentityUserRoles", "IdentityRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropColumn("dbo.IdentityUserRoles", "IdentityRole_Id");
            DropTable("dbo.IdentityRoles");
        }
    }
}
