using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSHCEnteties.Enteties
{
    public class RSHCPhone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Index(IsUnique = true)]
        [Required(ErrorMessage = "You must provide a phone number")]
        [StringLength(255)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }


        public bool isAssigned { get; set; } = false;

        public RSHCPhoneStatus Status { get; set; }

        public string Notes { get; set; }
         
        [Display(Name = "Previous Users")]
        public string PreviousUsers { get; set; }

       
        public string Extension { get; set; }

        public RSHCTier Tier { get; set; }

        [Display(Name = "Tier Department")]
        public RSHCTierDepartment TierDepartment { get; set; }


        [Display(Name = "RSHC eMail")]
        [StringLength(255)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string RSHCEMail { get; set; }


        [ForeignKey("RSHCEmployee")]
        public int? RSHCEmployeeId { get; set; }
        public virtual RSHCEmployee RSHCEmployee { get; set; }



        [Required]
        [Display(Name = "Office Location")]
        [ForeignKey("OfficeLocation")]
        public int OfficeLocationID { get; set; }
        public virtual OfficeLocation OfficeLocation { get; set; }
    }

    public enum RSHCTier
    {
        Unassigned,
        Attorney,
        Staff,
        CommonSpace,
    }

    public enum RSHCTierDepartment
    {
        Unassigned,
        EmploymentCounsel,
        AdminAssistant,
        ParalegalsProjectAssistant,
        Counsel,
        ITContractor,
        Associate,
        EquityPartner,
        Facilities,
        Administration,
        ConferenceRoom,
        IT,
        AccountingFinance,
        OfCounsel,
        CPO,
        IncomePartner,
        AdminDirector,
        CoCounsel,
        StaffAttorney,
        SeniorCounsel,
        Marketing,
        Interns,
        FinanceAccountsPayable,
        SupportStaff,
        Docket,
        LitSupport,
        LawClerk,
        Temp,
    }

    public enum RSHCPhoneStatus
    {
        Unassigned,
        System,
        Onsite,
        Offsite,
    }
}
