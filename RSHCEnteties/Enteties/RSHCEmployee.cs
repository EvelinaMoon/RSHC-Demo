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

       
        [StringLength(255)]
        public string UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string MI { get; set; }

        [Required]
        [StringLength(255)]
        public string DisplayName { get; set; }

        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string Initials { get; set; }



      
        public RSHCTitle Title { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }


        [StringLength(255)]
        public string PrivateEMail { get; set; }

        [StringLength(255)]
        public string RSHCEMail { get; set; }

        public DateTime? AdmittedIn { get; set; }

        public DateTime? AdmittedOut { get; set; }
        public string PathToImage { get; set; }



        [Display(Name = "Office Location")]
        [ForeignKey("OfficeLocation")]
        public int? OfficeLocationID { get; set; }
        public virtual OfficeLocation OfficeLocation { get; set; }



        public virtual ICollection<RSHCDeviceAssigment> DeviceAssigment { get; set; }
        public virtual ICollection<RSHCOffBoarding> RSHCOffBoarding { get; set; }
        public virtual ICollection<RSHCOnBoarding> RSHCOnBoarding { get; set; }

    }

    public enum RSHCTitle
    {
        IT = 1,
        
    }
}
    