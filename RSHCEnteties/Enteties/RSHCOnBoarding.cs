using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSHCEnteties.Enteties
{
    public class RSHCOnBoarding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // General info
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "On Boarding Started")]
        public DateTime? OnBoardingStarted { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "On Boarding Completed")]
        public DateTime? OnBoardingCompleted { get; set; }
        [Display(Name = "Serial Number")]

        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCEmployee")]
        public int RSHCEmployeeId { get; set; }
        public virtual RSHCEmployee RSHCEmployee { get; set; }

        [Display(Name = "On Boarding Status")]
        public RSHCBoardingStatus BoardingStatus { get; set; }

        // Check points
        public string SerialNumber { get; set; }
        [Display(Name = "Computer Name")]
        public string ComputerName { get; set; }
        [Display(Name = "RSHC Asset Tag")]
        public string RSHCAssetTag { get; set; }
        [Display(Name = "Create Admin account")]
        //1.0 Initial setup { get; set; }
        public bool CreateAdminaccount { get; set; }
        [Display(Name = "Turn off all features except Location")]
        public bool TurnOffFeatures { get; set; } = false;
        //2.0 Update Windows { get; set; }
        [Display(Name = "Win10 Enterprise Key")]
        public bool Win10EnterpriseKey { get; set; } = false;
        [Display(Name = @"Settings> Updates > Adv. Options > check \Give me…\")]
        public bool SettingsUpdateGiveMe { get; set; } = false;
        [Display(Name = "Win10 to most recent major update - Update Assistant if needed")]
        public bool Win10Updated { get; set; } = false;
        [Display(Name = "Check for updates until queue is clear")]
        public bool CheckForUpdates { get; set; } = false;
        [Display(Name = @"For non-Surface device > check for driver updates")]
        public bool NonSurfaceUpdates { get; set; } = false;
        //public bool General settings { get; set; }
        [Display(Name = "Add Apps account")]
        public bool AddAppsAccount { get; set; } = false;
        [Display(Name = "Private Network - Allow sharing")]
        public bool PrivateNetworkAllowSharing { get; set; } = false;
        //public bool Applications { get; set; }
        [Display(Name = "Office (64-bit)")]
        public bool Office64Bit { get; set; } = false;
        [Display(Name = "Acrobat DC (web installer)")]
        public bool AcrobatDC { get; set; } = false;
        [Display(Name = "Cisco Umbrella - w/ certificate - GP Network Status change")]
        public bool CiscoUmbrellaCertificate { get; set; } = false;
        [Display(Name = "Chrome")]
        public bool Chrome { get; set; } = false;
        [Display(Name = "Firefox")]
        public bool Firefox { get; set; } = false;
        [Display(Name = "E-Transcript Viewer")]
        public bool ETranscriptViewer { get; set; } = false;
        [Display(Name = "VLC Viewer")]
        public bool VLCViewer { get; set; } = false;
        //public bool LiteraSuite { get; set; }
        [Display(Name = "MS Visual Studio Runtime 2010")]
        public bool MSVisualStudioRuntime2010 { get; set; } = false;
        [Display(Name = @"MS visual C++ 2015-2019 Redist. - both x86 and x64")]
        public bool MSVisualC4 { get; set; } = false;
        [Display(Name = "Change-Pro")]
        public bool ChangePro { get; set; } = false;
        [Display(Name = "Metadact")]
        public bool Metadact { get; set; } = false;
        [Display(Name = "Litera Admin Panel - the version packaged with Metadact")]
        public bool LiteraMetadact { get; set; } = false;
        [Display(Name = "DocX Tools Companion - Litera Tab option")]
        public bool DocXLitera { get; set; } = false;
        [Display(Name = "Contract Companion - Litera Tab / Litera Check options")]
        public bool ContractCompanionLitera { get; set; } = false;
        //public bool NetDocuments via ND Direct Downloads page { get; set; }
        [Display(Name = "ndOffice")]
        public bool NDOffice { get; set; } = false;
        [Display(Name = "ndClick - /w Chrome extension")]
        public bool NDClickChromeExtension { get; set; } = false;
        [Display(Name = "ndMail")]
        public bool ndMail { get; set; } = false;
        //public bool Applications(post rename) { get; set; }
        [Display(Name = @"Meraki - m.meraki.com - 118-226-7401")]
        public bool Meraki { get; set; } = false;
        [Display(Name = "LogMeIn client")]
        public bool LogMeInClient { get; set; } = false;
        [Display(Name = "Sophos (reboot)")]
        public bool SophosReboot { get; set; } = false;
        //public bool Surface hardware { get; set; }
        [Display(Name = "Privacy Screen")]
        public bool PrivacyScreen { get; set; } = false;
        [Display(Name = "Protective Case")]
        public bool ProtectiveCase { get; set; } = false;
        //public bool User Setup { get; set; }
        [Display(Name = "Set Time Zone")]
        public bool SetTimeZone { get; set; } = false;
        [Display(Name = "Join device to Azure AD via user login")]
        public bool JoinAzureAD { get; set; } = false;
        [Display(Name = "Log in as user - set up PIN and Hello (if able)")]
        public bool LoginUserPIN { get; set; } = false;
        //public bool User settings { get; set; }
        [Display(Name = "Internet Explorer - Recommended settings > turn off TLS 1.0/1.1")]
        public bool InternetTurnOffTLS { get; set; } = false;
        [Display(Name = @"IE/Chrome/Firefox/Edge - homepage: google.com - turn off password saving")]
        public bool BrowserTurnOffPasswordSaving { get; set; } = false;
        [Display(Name = @"Set Default apps - Email: Outlook - Web Browser: Chrome")]
        public bool SetDefaultApps { get; set; } = false;
        [Display(Name = "Disable OneDrive")]
        public bool DisableOneDrive { get; set; } = false;
        [Display(Name = "Run NetDocs registry keys")]
        public bool NetDocsRegistryKeys { get; set; } = false;
        [Display(Name = "ndOffice Settings > ID Stamp > Last page")]
        public bool NDOfficeIDStamp { get; set; } = false;
        [Display(Name = @"Litera Admin Panel - Set ND - Adobe PDF - Metadact to \Local\")]
        public bool LiteraSetMetadact { get; set; } = false;
        [Display(Name = "Back up BitLocker Key to Azure AD account")]
        public bool BackBitLockerAzureKey { get; set; } = false;
        [Display(Name = "Open Outlook and add user - Turn off autocomplete and auto-name checking")]
        public bool OutlookTurnOffAutocomplete { get; set; } = false;
        [Display(Name = "Open Acrobat - log in user - set PDF default to Acrobat")]
        public bool AcrobatSetPDF { get; set; } = false;
        [Display(Name = "pen Zoom - log in user")]
        public bool ZoomLogInUser { get; set; } = false;
        [Display(Name = @"<Attorney> iTimekeep add-in and link: https://services.bellefieldcloud.com/")]
        public bool AttorneyiTimekeep { get; set; } = false;
        //public bool A New user steps { get; set; }
        [Display(Name = "Add Zeb's Custom Office Templates to Documents")]       
        public bool AddZebsOfficeTemplates { get; set; } = false;
        [Display(Name = "Set up Outlook email Signature via template")]
        public bool OutlookSignaturee { get; set; } = false;
        [Display(Name = @"Add closest Xerox and HP printer(s)")] 
        public bool AddXerox { get; set; } = false;
        //public bool New device steps { get; set; }
        [Display(Name = @"Copy/move files from old device + ndEcho - signature - browser bookmarks")]      
        public bool CopyMoveFiles { get; set; } = false;
        [Display(Name = "Activate signature in Outlook")]
        public bool OutlookActivateSignature { get; set; } = false;
        [Display(Name = "Add printers from old device")]
        public bool AddPrinters { get; set; } = false;
        //public bool Software installed via push(check for proper install) { get; set; }
        [Display(Name = @"Citrix GoToAssist - unattended client")]        
        public bool CitrixClient { get; set; } = false;
        [Display(Name = "7-Zip")]
        public bool SevenZip { get; set; } = false;
        [Display(Name = "Zoom client")]
        public bool ZoomClient { get; set; } = false;
    }
}
