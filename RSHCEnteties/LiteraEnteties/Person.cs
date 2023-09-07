namespace RSHCEnteties
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persons")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Licenses = new HashSet<License>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
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

        [Display(Name = "Office Location")]
        public int? OfficeID { get; set; }

        [StringLength(255)]
        public string ShortName { get; set; }

        public bool? IsAttorney { get; set; }

        public bool? IsAuthor { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string EMail { get; set; }

        public DateTime? AdmittedIn { get; set; }

        public virtual OfficeLocation OfficeLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<License> Licenses { get; set; }
    }
}
