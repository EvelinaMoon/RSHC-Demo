namespace RSHCEnteties.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RSHCBoardingadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RSHCOffBoardings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OffBoardingStarted = c.DateTime(),
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
                        RSHCEmployee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployee_ID)
                .Index(t => t.RSHCEmployeeId)
                .Index(t => t.RSHCEmployee_ID);
            
            CreateTable(
                "dbo.RSHCOnBoardings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OnBoardingStarted = c.DateTime(),
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
                        RSHCEmployee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.RSHCEmployees", t => t.RSHCEmployee_ID)
                .Index(t => t.RSHCEmployeeId)
                .Index(t => t.RSHCEmployee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RSHCOnBoardings", "RSHCEmployee_ID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOnBoardings", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOffBoardings", "RSHCEmployee_ID", "dbo.RSHCEmployees");
            DropForeignKey("dbo.RSHCOffBoardings", "RSHCEmployeeId", "dbo.RSHCEmployees");
            DropIndex("dbo.RSHCOnBoardings", new[] { "RSHCEmployee_ID" });
            DropIndex("dbo.RSHCOnBoardings", new[] { "RSHCEmployeeId" });
            DropIndex("dbo.RSHCOffBoardings", new[] { "RSHCEmployee_ID" });
            DropIndex("dbo.RSHCOffBoardings", new[] { "RSHCEmployeeId" });
            DropTable("dbo.RSHCOnBoardings");
            DropTable("dbo.RSHCOffBoardings");
        }
    }
}
