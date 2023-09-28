namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28092023DBInitBasicModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        MiddleName = c.String(maxLength: 255),
                        AdmittedIn = c.DateTime(nullable: false),
                        AdmittedOut = c.DateTime(),
                        UserRole = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.String(maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        Jurisdiction = c.String(maxLength: 255, unicode: false),
                        License = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Persons", t => t.OwnerID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 255, unicode: false),
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 255, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 255, unicode: false),
                        MI = c.String(maxLength: 255, unicode: false),
                        DisplayName = c.String(nullable: false, maxLength: 255, unicode: false),
                        FullName = c.String(maxLength: 255, unicode: false),
                        Initials = c.String(maxLength: 255, unicode: false),
                        OfficeID = c.Int(),
                        ShortName = c.String(maxLength: 255, unicode: false),
                        IsAttorney = c.Boolean(),
                        IsAuthor = c.Boolean(),
                        Title = c.String(maxLength: 255, unicode: false),
                        Phone = c.String(maxLength: 255, unicode: false),
                        Fax = c.String(maxLength: 255, unicode: false),
                        EMail = c.String(maxLength: 255, unicode: false),
                        AdmittedIn = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeID)
                .Index(t => t.OfficeID);
            
            CreateTable(
                "dbo.OfficeLocations",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OfficeValue = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RSHCDevices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SerialNumber = c.String(nullable: false, maxLength: 255),
                        DeviceStatus = c.Int(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        RAM = c.String(),
                        SSDSize = c.String(),
                        ComputerName = c.String(),
                        BuildDate = c.DateTime(),
                        Notes = c.String(),
                        PathToImage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.SerialNumber, unique: true);
            
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
                        UserID = c.String(nullable: false, maxLength: 255),
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
                        PathToImage = c.String(),
                        OfficeLocationID = c.Int(nullable: false),
                        RSHCOffBoardingID = c.Int(),
                        RSHCOnBoardingID = c.Int(),
                        RSHCPhoneID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationID, cascadeDelete: true)
                .Index(t => t.UserID, unique: true)
                .Index(t => t.PrivateEMail, unique: true)
                .Index(t => t.RSHCEMail, unique: true)
                .Index(t => t.OfficeLocationID);
            
            CreateTable(
                "dbo.RSHCOffBoardings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OffBoardingStarted = c.DateTime(nullable: false),
                        OffBoardingCompleted = c.DateTime(),
                        BoardingStatus = c.Int(nullable: false),
                        RSHCEmployeeId = c.Int(nullable: false),
                        RSHCDevicesReturned = c.Boolean(nullable: false),
                        O365WipeMobileDevices = c.Boolean(nullable: false),
                        O365PasswordChanged = c.Boolean(nullable: false),
                        O365ForceLogout = c.Boolean(nullable: false),
                        O365ClearContactInfo = c.Boolean(nullable: false),
                        O365AddTerminatedTitle = c.Boolean(nullable: false),
                        O365RemoveFromGroups = c.Boolean(nullable: false),
                        O365SetAutoreply = c.Boolean(nullable: false),
                        O365SetHideFromGAL = c.Boolean(nullable: false),
                        NetDoctsCheckInAllDocs = c.Boolean(nullable: false),
                        NetDocUserGUIDToWorksheet = c.Boolean(nullable: false),
                        NetDocCheckDeletedDocuments = c.Boolean(nullable: false),
                        NetDoCloseAuthorID = c.Boolean(nullable: false),
                        NetDocCheckPersonalMatter = c.Boolean(nullable: false),
                        NetDocDeleteMobileDevice = c.Boolean(nullable: false),
                        NetDocTermUser = c.Boolean(nullable: false),
                        AdobeAcrobatDeleteUser = c.Boolean(nullable: false),
                        FaxPlusDeleteUser = c.Boolean(nullable: false),
                        NordLayerDeleteUser = c.Boolean(nullable: false),
                        ITimekeepDeleteUser = c.Boolean(nullable: false),
                        SharefileDisableAccount = c.Boolean(nullable: false),
                        SharefileLicensed = c.Boolean(nullable: false),
                        SharefileRemoveLicense = c.Boolean(nullable: false),
                        SharefileFoldersToSupport = c.Boolean(nullable: false),
                        ZoomForwardToReception = c.Boolean(nullable: false),
                        PCWiped = c.Boolean(nullable: false),
                        KeycardsPhysicallyDisable = c.Boolean(nullable: false),
                        ChicagoInformBuilding = c.Boolean(nullable: false),
                        PSTArchiveContent = c.Boolean(nullable: false),
                        PSTSavedToPSTOrNAS = c.Boolean(nullable: false),
                        O365ZoomDeleteUser = c.Boolean(nullable: false),
                        DeleteO365ZoomUserBy = c.DateTime(),
                        RSHCOffBoardingID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCOffBoardingID)
                .Index(t => t.RSHCEmployeeId, unique: true)
                .Index(t => t.RSHCOffBoardingID);
            
            CreateTable(
                "dbo.RSHCOnBoardings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OnBoardingStarted = c.DateTime(nullable: false),
                        OnBoardingCompleted = c.DateTime(),
                        RSHCEmployeeId = c.Int(nullable: false),
                        BoardingStatus = c.Int(nullable: false),
                        SerialNumber = c.String(),
                        ComputerName = c.String(),
                        RSHCAssetTag = c.String(),
                        CreateAdminaccount = c.Boolean(nullable: false),
                        TurnOffFeatures = c.Boolean(nullable: false),
                        Win10EnterpriseKey = c.Boolean(nullable: false),
                        SettingsUpdateGiveMe = c.Boolean(nullable: false),
                        Win10Updated = c.Boolean(nullable: false),
                        CheckForUpdates = c.Boolean(nullable: false),
                        NonSurfaceUpdates = c.Boolean(nullable: false),
                        AddAppsAccount = c.Boolean(nullable: false),
                        PrivateNetworkAllowSharing = c.Boolean(nullable: false),
                        Office64Bit = c.Boolean(nullable: false),
                        AcrobatDC = c.Boolean(nullable: false),
                        CiscoUmbrellaCertificate = c.Boolean(nullable: false),
                        Chrome = c.Boolean(nullable: false),
                        Firefox = c.Boolean(nullable: false),
                        ETranscriptViewer = c.Boolean(nullable: false),
                        VLCViewer = c.Boolean(nullable: false),
                        MSVisualStudioRuntime2010 = c.Boolean(nullable: false),
                        MSVisualC4 = c.Boolean(nullable: false),
                        ChangePro = c.Boolean(nullable: false),
                        Metadact = c.Boolean(nullable: false),
                        LiteraMetadact = c.Boolean(nullable: false),
                        DocXLitera = c.Boolean(nullable: false),
                        ContractCompanionLitera = c.Boolean(nullable: false),
                        NDOffice = c.Boolean(nullable: false),
                        NDClickChromeExtension = c.Boolean(nullable: false),
                        ndMail = c.Boolean(nullable: false),
                        Meraki = c.Boolean(nullable: false),
                        LogMeInClient = c.Boolean(nullable: false),
                        SophosReboot = c.Boolean(nullable: false),
                        PrivacyScreen = c.Boolean(nullable: false),
                        ProtectiveCase = c.Boolean(nullable: false),
                        SetTimeZone = c.Boolean(nullable: false),
                        JoinAzureAD = c.Boolean(nullable: false),
                        LoginUserPIN = c.Boolean(nullable: false),
                        InternetTurnOffTLS = c.Boolean(nullable: false),
                        BrowserTurnOffPasswordSaving = c.Boolean(nullable: false),
                        SetDefaultApps = c.Boolean(nullable: false),
                        DisableOneDrive = c.Boolean(nullable: false),
                        NetDocsRegistryKeys = c.Boolean(nullable: false),
                        NDOfficeIDStamp = c.Boolean(nullable: false),
                        LiteraSetMetadact = c.Boolean(nullable: false),
                        BackBitLockerAzureKey = c.Boolean(nullable: false),
                        OutlookTurnOffAutocomplete = c.Boolean(nullable: false),
                        AcrobatSetPDF = c.Boolean(nullable: false),
                        ZoomLogInUser = c.Boolean(nullable: false),
                        AttorneyiTimekeep = c.Boolean(nullable: false),
                        AddZebsOfficeTemplates = c.Boolean(nullable: false),
                        OutlookSignaturee = c.Boolean(nullable: false),
                        AddXerox = c.Boolean(nullable: false),
                        CopyMoveFiles = c.Boolean(nullable: false),
                        OutlookActivateSignature = c.Boolean(nullable: false),
                        AddPrinters = c.Boolean(nullable: false),
                        CitrixClient = c.Boolean(nullable: false),
                        SevenZip = c.Boolean(nullable: false),
                        ZoomClient = c.Boolean(nullable: false),
                        RSHCOnBoardingID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCOnBoardingID)
                .Index(t => t.RSHCEmployeeId, unique: true)
                .Index(t => t.RSHCOnBoardingID);
            
            CreateTable(
                "dbo.RSHCPhones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false, maxLength: 255),
                        isAssigned = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Notes = c.String(),
                        PreviousUsers = c.String(),
                        Extension = c.String(),
                        Tier = c.Int(nullable: false),
                        TierDepartment = c.Int(nullable: false),
                        RSHCEMail = c.String(maxLength: 255),
                        RSHCEmployeeId = c.Int(nullable: true),
                        OfficeLocationID = c.Int(nullable: false),
                        RSHCPhoneID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OfficeLocations", t => t.OfficeLocationID, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCPhoneID)
                .Index(t => t.Phone, unique: true)
                .Index(t => t.RSHCEmployeeId)
                .Index(t => t.OfficeLocationID)
                .Index(t => t.RSHCPhoneID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCDevice_ID", "dbo.RSHCDevices");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCPhones", "RSHCPhoneID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCPhones", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCPhones", "OfficeLocationID", "dbo.OfficeLocations");
            DropForeignKey("dbo.RSHCOnBoardings", "RSHCOnBoardingID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOnBoardings", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOffBoardings", "RSHCOffBoardingID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOffBoardings", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCEmployees", "OfficeLocationID", "dbo.OfficeLocations");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCEmployee_ID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCDeviceAssigments", "RSHCDeviceId", "dbo.RSHCDevices");
            DropForeignKey("dbo.Persons", "OfficeID", "dbo.OfficeLocations");
            DropForeignKey("dbo.Licenses", "OwnerID", "dbo.Persons");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.RSHCPhones", new[] { "RSHCPhoneID" });
            DropIndex("dbo.RSHCPhones", new[] { "OfficeLocationID" });
            DropIndex("dbo.RSHCPhones", new[] { "RSHCEmployeeId" });
            DropIndex("dbo.RSHCPhones", new[] { "Phone" });
            DropIndex("dbo.RSHCOnBoardings", new[] { "RSHCOnBoardingID" });
            DropIndex("dbo.RSHCOnBoardings", new[] { "RSHCEmployeeId" });
            DropIndex("dbo.RSHCOffBoardings", new[] { "RSHCOffBoardingID" });
            DropIndex("dbo.RSHCOffBoardings", new[] { "RSHCEmployeeId" });
            DropIndex("dbo.RSHCEmployees", new[] { "OfficeLocationID" });
            DropIndex("dbo.RSHCEmployees", new[] { "RSHCEMail" });
            DropIndex("dbo.RSHCEmployees", new[] { "PrivateEMail" });
            DropIndex("dbo.RSHCEmployees", new[] { "UserID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCDevice_ID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCEmployee_ID" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCDeviceId" });
            DropIndex("dbo.RSHCDeviceAssigments", new[] { "RSHCEmployeeId" });
            DropIndex("dbo.RSHCDevices", new[] { "SerialNumber" });
            DropIndex("dbo.Persons", new[] { "OfficeID" });
            DropIndex("dbo.Licenses", new[] { "OwnerID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropTable("dbo.RSHCPhones");
            DropTable("dbo.RSHCOnBoardings");
            DropTable("dbo.RSHCOffBoardings");
            DropTable("dbo.RSHCEmployees");
            DropTable("dbo.RSHCDeviceAssigments");
            DropTable("dbo.RSHCDevices");
            DropTable("dbo.OfficeLocations");
            DropTable("dbo.Persons");
            DropTable("dbo.Licenses");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
        }
    }
}
