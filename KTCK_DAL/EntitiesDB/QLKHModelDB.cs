using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KTCK_DAL.EntitiesDB
{
    public partial class QLKHModelDB : DbContext
    {
        public QLKHModelDB()
            : base("name=QLKHModelDB1")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .Property(e => e.CourseID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentID)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.CourseID)
                .IsUnicode(false);
        }
    }
}
