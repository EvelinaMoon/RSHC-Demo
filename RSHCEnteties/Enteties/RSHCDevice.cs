﻿using System;
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

          
        public string SerialNumber { get; set; }
        public RSHCDeviceStatus DeviceStatus { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string RAM { get; set; }
        public string SSDSize { get; set; }
        public string ComputerName { get; set; }
        public DateTime? BuildDate { get; set; }
        public string Notes { get; set; }


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
