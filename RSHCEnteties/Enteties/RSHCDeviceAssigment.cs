﻿using System;
using System.Collections.Generic;
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
        public DateTime AssignedDate { get; set; }
        public AssigmentStatus Status { get; set; }
        public string Notes { get; set; }


        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCEmployee")]
        public int RSHCEmployeeId { get; set; }
        public virtual RSHCEmployee RSHCEmployee { get; set; }


        // This will be recognized as FK by NavigationPropertyNameForeignKeyDiscoveryConvention
        [ForeignKey("RSHCDevice")]
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