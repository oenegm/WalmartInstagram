namespace WalmartInstagram.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("post")]
    public partial class post
    {
        [Required]
        [StringLength(50)]
        public string writerUsername { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Caption or Content")]
        public string postContent { get; set; }

        [Required]
        [Display(Name = "Upload Picture")]
        public string picture { get; set; }

        public int postID { get; set; }
        
        public int catID { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime date { get; set; }
        public virtual category category { get; set; }

        public virtual user user { get; set; }
    }
}
