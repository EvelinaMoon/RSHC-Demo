using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RSHCEnteties.Enteties
{
    public class RSHCDeviceAssigment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Assigned Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime AssignedDate { get; set; }
        public AssigmentStatus Status { get; set; }
        public string Notes { get; set; }


        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCEmployee")]
        [Display(Name = "RSHC Employee Id")]
        [Required]
        public int RSHCEmployeeId { get; set; }
        public virtual RSHCEmployee RSHCEmployee { get; set; }


        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCDevice")]
        [Display(Name = "RSHC DeviceId")]
        [Required]
        public int RSHCDeviceId { get; set; }
        public virtual RSHCDevice RSHCDevice { get; set; }

    }

    public enum AssigmentStatus
    {
        Unknown = 0,
        Allocated = 1,
        Assigned = 2,
        Returned = 3,
    }
}
