using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR.DataAccess.Models
{
    public partial class HR_ProjectContext : DbContext
    {
        public HR_ProjectContext()
        {
        }
        public HR_ProjectContext(DbContextOptions<HR_ProjectContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=WINDELL-MDP3TD6;Initial Catalog=HR_Project2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public virtual DbSet<JobOffer> Offers { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Microsoft" },
                new Company() { Id = 2, Name = "Google" },
                new Company() { Id = 3, Name = "Netcompany" },
                new Company() { Id = 4, Name = "ITBoom" },
                new Company() { Id = 5, Name = "KMD" },
                new Company() { Id = 6, Name = "Pwc" }
                );

            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer() { Id = 1, CompanyId = 1, DateExpiration = DateTime.Now, SalaryFrom = 8000, SalaryTo = 10000, Position = ".Net Senior" },
                new JobOffer() { Id = 2, CompanyId = 2, DateExpiration = DateTime.Now, SalaryFrom = 1000, SalaryTo = 2000, Position = ".Net Junior" },
                new JobOffer() { Id = 3, CompanyId = 3, DateExpiration = DateTime.Now, SalaryFrom = 5000, SalaryTo = 7000, Position = ".Net Mid" }
                );

            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication() { Id = 1, JobOfferId = 1, PhoneNumber = "123456789", ContactAgreement = true, ApplicationDate = DateTime.Now, EmailAddress = "rocky@nowak.com", UserId = 1 },
                new JobApplication() { Id = 2, JobOfferId = 3, PhoneNumber = "123456789", ContactAgreement = false, ApplicationDate = DateTime.Now, FirstName = "Rocky", LastName = "Nowak", EmailAddress = "rocky@nowak.com", UserId = 1 }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, RoleName = "User" },
                new Role() { Id = 2, RoleName = "HRUser" },
                new Role() { Id = 3, RoleName = "Admin" }
                );

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = 1, Name = "Rocky", Lastname = "Nowak", Email = "rocky@nowak.com", RoleId = 1 }
                );
        }

    }
}
