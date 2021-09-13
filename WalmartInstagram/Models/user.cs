namespace WalmartInstagram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            posts = new HashSet<post>();
        }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string lastName { get; set; }

        [Key]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string username { get; set; }

        [Display(Name = "Phone Number")]
        public int phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50)]
        public string password { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [StringLength(50)]
        public string confirmPassword { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [Display(Name = "Upload Profile Picture")]
        public string profilePic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> posts { get; set; }
    }
}
