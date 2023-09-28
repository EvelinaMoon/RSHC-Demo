using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSHCEnteties.Enteties
{
    public class RSHCDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public RSHCDeviceStatus DeviceStatus { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string RAM { get; set; }
        [Display(Name = "SSD Size")]
        public string SSDSize { get; set; }
        [Display(Name = "Computer Name")]
        public string ComputerName { get; set; }
        [Display(Name = "Build Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? BuildDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Path To Image")]
        public string PathToImage { get; set; }


        public virtual ICollection<RSHCDeviceAssigment> DeviceAssigment { get; set; }

    }

    public enum RSHCDeviceStatus
    {
        Unknown = 0,
        Deployed = 1,
        InStock = 2,
        Retierd = 3,
        Disposed = 4,
    }
}
