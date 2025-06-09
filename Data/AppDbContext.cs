using Microsoft.EntityFrameworkCore;
using System;
using TeacherMgmt.Models;
namespace TeacherMgmt.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<ClassInfo> ClassInfo { get; set; }
        public DbSet<Subjectinfo> Subject { get; set; }
        public DbSet<SubSubject> SubSubjects { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subjectinfo>()
                .HasIndex(s => s.SubjectCode)
                .IsUnique(); // Make SubjectCode an alternate key

            modelBuilder.Entity<SubSubject>()
                .HasOne(s => s.Subject) // navigation property in SubSubject
                .WithMany(s => s.SubSubjects) // navigation property in Subjectinfo
                .HasForeignKey(s => s.SubjectCode) // FK in SubSubject
                .HasPrincipalKey(s => s.SubjectCode); // maps to alternate key in Subjectinfo
        }

    }
    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
