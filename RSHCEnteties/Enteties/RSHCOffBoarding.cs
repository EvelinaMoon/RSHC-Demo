using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.XEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RSHCEnteties.Enteties
{
    public class RSHCOffBoarding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Off Boarding Started")]
        public DateTime? OffBoardingStarted { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Off Boarding Complited")]
        public DateTime? OffBoardingCompleted { get; set; }

        [Display(Name = "Off Boarding Status")]
        public RSHCBoardingStatus BoardingStatus { get; set; }

        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCEmployee")]
        public int RSHCEmployeeId { get; set; }
        public virtual RSHCEmployee RSHCEmployee { get; set; }


        [Display(Name = "RSHC devices returned")]
        public bool RSHCDevicesReturned { get; set; } = false;
        [Display(Name = "App wipe created for Mobile devices")]
        public bool O365WipeMobileDevices { get; set; } = false;
        [Display(Name = "Password changed")]
        public bool O365PasswordChanged { get; set; } = false;
        [Display(Name = "Force logout of O365 sessions")]
        public bool O365ForceLogout { get; set; } = false;

        [Display(Name = "Clear contact info")]
        public bool O365ClearContactInfo { get; set; } = false;
        [Display(Name = @"Add \System [Terminated]\ to Dept and Title")]
        public bool O365AddTerminatedTitle { get; set; } = false;
        [Display(Name = "Remove from manually assigned Groups")]
        public bool O365RemoveFromGroups { get; set; } = false;
        [Display(Name = "Set autoreply")]
        public bool O365SetAutoreply { get; set; } = false;
        [Display(Name = "Set hide from GAL")]
        public bool O365SetHideFromGAL { get; set; } = false;
        [Display(Name = "Check-in all documents")]
        public bool NetDoctsCheckInAllDocs { get; set; } = false;
        [Display(Name = "Add User GUID from User report to tracking worksheet")]
        public bool NetDocUserGUIDToWorksheet { get; set; } = false;
        [Display(Name = "Check deleted documents")]
        public bool NetDocCheckDeletedDocuments { get; set; } = false;
        [Display(Name = "Close Author ID")]
        public bool NetDoCloseAuthorID { get; set; } = false;
        [Display(Name = "Check personal matter")]
        public bool NetDocCheckPersonalMatter { get; set; } = false;
        [Display(Name = "Delete mobile device")]
        public bool NetDocDeleteMobileDevice { get; set; } = false;
        [Display(Name = "Term user")]
        public bool NetDocTermUser { get; set; }
        [Display(Name = @"Adobe Acrobat Delete user")]
        public bool AdobeAcrobatDeleteUser { get; set; } = false;
        [Display(Name = @"FaxPlus  user")]
        public bool FaxPlusDeleteUser { get; set; } = false;
        [Display(Name = "NordLayer Delete user")]
        public bool NordLayerDeleteUser { get; set; } = false;
        [Display(Name = "iTimekeep Delete user")]
        public bool ITimekeepDeleteUser { get; set; } = false;
        [Display(Name = "Sharefile Disable account")]
        public bool SharefileDisableAccount { get; set; } = false;
        [Display(Name = "Sharefile is Licensed")]
        public bool SharefileLicensed { get; set; } = false;
        [Display(Name = "Sharefile Remove License")]
        public bool SharefileRemoveLicense { get; set; } = false;
        [Display(Name = "Sharefile Delegate folders to Lit Support")]
        public bool SharefileFoldersToSupport { get; set; } = false;
        [Display(Name = "Zoom Forward to Reception")]
        public bool ZoomForwardToReception { get; set; } = false;
        [Display(Name = "PC Wiped")]
        public bool PCWiped { get; set; } = false;
        [Display(Name = "Keycards Physically recover and/or disable on prem")]
        public bool KeycardsPhysicallyDisable { get; set; } = false;
        [Display(Name = @"Chicago > Inform building of term")]
        public bool ChicagoInformBuilding { get; set; } = false;
        [Display(Name = @"PST Archive Created Compliance.Microsoft.com/Content Search")]
        public bool PSTArchiveContent { get; set; } = false;
        [Display(Name = @"PST saved to F:\\PST\\PST or NAS")]
        public bool PSTSavedToPSTOrNAS { get; set; } = false;
        [Display(Name = "O365/Zoom Delete user (staff = 1mon, atty = 6 mon)")]
        public bool O365ZoomDeleteUser { get; set; } = false;

        [Display(Name = @"Delete O365/Zoom User By Following Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime? DeleteO365ZoomUserBy { get; set; }
    }

    public enum RSHCBoardingStatus
    {
        Unknown = 0,
        Started = 1,
        Paused = 2,
        Complited = 3,
        Terminated = 4,
    }
}
