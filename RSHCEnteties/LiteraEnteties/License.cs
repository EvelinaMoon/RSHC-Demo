namespace RSHCEnteties
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class License
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string OwnerID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Jurisdiction { get; set; }

        [Display(Name = "License")]
        [Column("License")]
        [StringLength(255)]
        public string License1 { get; set; }

        public virtual Person Person { get; set; }
    }
}
