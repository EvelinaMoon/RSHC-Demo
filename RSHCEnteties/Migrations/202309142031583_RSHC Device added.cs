namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RSHCDeviceadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RSHCDevices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        DeviceStatus = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        RAM = c.String(),
                        SSDSize = c.String(),
                        ComputerName = c.String(),
                        BuildDate = c.DateTime(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RSHCDeviceAssigments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssignedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Notes = c.String(),
                        RSHCEmployeeId = c.Int(nullable: false),
                        RSHCDeviceId = c.Int(nullable: false),
                        RSHCEmployee_ID = c.Int(),
                        RSHCDevice_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RSHCDevices", t => t.RSHCDeviceId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployee_ID)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCDevices", t => t.RSHCDevice_ID)
                .Index(t => t.RSHCEmployeeId)
                .Index(t => t.RSHCDeviceId)
                .Index(t => t.RSHCEmployee_ID)
                .Index(t => t.RSHCDevice_ID);
            
            CreateTable(
                "dbo.RSHCEmployees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        MI = c.String(maxLength: 255),
                        DisplayName = c.String(nullable: false, maxLength: 255),
                        FullName = c.String(maxLength: 255),
                        Initials = c.String(maxLength: 255),
                        Title = c.Int(nullable: false),
                        Phone = c.String(maxLength: 255),
                        PrivateEMail = c.String(maxLength: 255),
                        RSHCEMail = c.String(maxLength: 255),
                        AdmittedIn = c.DateTime(),
                        AdmittedOut = c.DateTime(),
                        OfficeLocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationID, cascadeDelete: true)
                .Index(t => t.OfficeLocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCDevice_ID", "dbo.RSHCDevices");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCEmployees", "OfficeLocationID", "dbo.OfficeLocations");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCEmployee_ID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCDeviceId", "dbo.RSHCDevices");
            DropIndex("dbo.RSHCEmployees", new[] { "OfficeLocationID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCDevice_ID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCEmployee_ID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCDeviceId" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCEmployeeId" });
            DropTable("dbo.RSHCEmployees");
            DropTable("dbo.RSHCDeviceAssigments");
            DropTable("dbo.RSHCDevices");
        }
    }
}
