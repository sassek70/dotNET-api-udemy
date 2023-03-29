using DotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPI.Data
{
    public class DataContextEF : DbContext
    {
        private readonly IConfiguration _config;
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<UserSalary> UserSalary {get; set;}
        public virtual DbSet<UserJobInfo> UserJobInfo {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<User>().ToTable("Users", "TutorialAppSchema").HasKey(user => user.UserId);
            modelBuilder.Entity<UserJobInfo>().HasKey(user => user.UserId);
            modelBuilder.Entity<UserSalary>().HasKey(user => user.UserId);
            // modelBuilder.Entity<UserSalary>().HasOne<User>(u => u.User);

            modelBuilder.Entity<UserSalary>(e =>
            { e.HasOne(u => u.User).WithOne(s => s.salary).HasForeignKey<UserSalary>(u => u.UserId);
            });
            // modelBuilder.Entity<UserJobInfo>().HasOne(u => u.User);
            // modelBuilder.Entity<User>().HasOne("Salary");
            // modelBuilder.Entity<User>().HasOne(u => u.Department);
            // modelBuilder.Entity<User>().HasOne(u => u.JobTitle);

        }
    }
}