using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WalmartInstagram.Models
{
    public partial class instagramContext : DbContext
    {
        public instagramContext()
            : base("name=instagramContext")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.posts)
                .WithRequired(e => e.category)
                .HasForeignKey(e => e.catID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.posts)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.writerUsername)
                .WillCascadeOnDelete(false);
        }
    }
}
