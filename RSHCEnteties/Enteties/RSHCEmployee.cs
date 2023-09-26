using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSHCEnteties.Enteties
{
    public class RSHCEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(255)]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string MI { get; set; }
        [Display(Name = "Display Name")]
        [Required]
        [StringLength(255)]
        public string DisplayName { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Initials { get; set; }



      
        public RSHCTitle Title { get; set; }

        [StringLength(255)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Private eMail")]
        [StringLength(255)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string PrivateEMail { get; set; }
        [Display(Name = "RSHC eMail")]
        [StringLength(255)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string RSHCEMail { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Admitted In")]
        public DateTime? AdmittedIn { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Display(Name = "Admitted Out")]
        public DateTime? AdmittedOut { get; set; }
        [Display(Name = "Path To Image")]
        public string PathToImage { get; set; }


        [Required]
        [Display(Name = "Office Location")]
        [ForeignKey("OfficeLocation")]
        public int? OfficeLocationID { get; set; }
        public virtual OfficeLocation OfficeLocation { get; set; }



        public virtual ICollection<RSHCDeviceAssigment> DeviceAssigment { get; set; }

        [Display(Name = "RSHC OffBoarding")]
        public int? RSHCOffBoardingID { get; set; }
        public virtual RSHCOffBoarding RSHCOffBoarding { get; set; }

        [Display(Name = "RSHC OnBoarding")]
        public int? RSHCOnBoardingID { get; set; }
        public virtual RSHCOnBoarding RSHCOnBoarding { get; set; }


        [Display(Name = "Office Phone")]
        public int? RSHCPhoneID { get; set; }
        public virtual RSHCPhone RSHCPhone { get; set; }

    }

    public enum RSHCTitle
    {
        IT = 1,
        
    }
}
    