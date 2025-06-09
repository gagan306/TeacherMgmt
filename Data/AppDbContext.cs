using Microsoft.EntityFrameworkCore;
using System;
using TeacherMgmt.Models;
namespace TeacherMgmt.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<ClassInfo> ClassInfo { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    }
    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
