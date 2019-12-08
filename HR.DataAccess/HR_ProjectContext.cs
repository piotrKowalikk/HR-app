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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

        //    modelBuilder.Entity<JobOffer>(entity =>
        //    {
        //        entity.ToTable("APP_JOBOFFERS");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Company)
        //            .IsRequired()
        //            .HasColumnName("company")
        //            .HasMaxLength(30)
        //            .IsUnicode(false);

        //        entity.Property(e => e.DateExpiration)
        //            .HasColumnName("dateExpiration")
        //            .HasColumnType("date");

        //        entity.Property(e => e.DatePosted)
        //            .HasColumnName("datePosted")
        //            .HasColumnType("date");

        //        entity.Property(e => e.Description)
        //            .IsRequired()
        //            .HasColumnName("description")
        //            .HasColumnType("text");

        //        entity.Property(e => e.IsActive).HasColumnName("isActive");

        //        entity.Property(e => e.Position)
        //            .IsRequired()
        //            .HasColumnName("position")
        //            .HasMaxLength(30)
        //            .IsUnicode(false);

        //        entity.Property(e => e.SalaryFrom).HasColumnName("salaryFrom");

        //        entity.Property(e => e.SalaryTo).HasColumnName("salaryTo");

        //        entity.Property(e => e.UserApply).HasColumnName("userApply");

        //        entity.Property(e => e.UserPosting).HasColumnName("userPosting");


        //    });

        //    modelBuilder.Entity<ApplicationUser>(entity =>
        //    {
        //        entity.ToTable("APP_USERS");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Email)
        //            .IsRequired()
        //            .HasColumnName("email")
        //            .HasMaxLength(30);

        //        entity.Property(e => e.Lastname)
        //            .IsRequired()
        //            .HasColumnName("lastname")
        //            .HasMaxLength(20);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasColumnName("name")
        //            .HasMaxLength(20);

        //        entity.Property(e => e.RoleId).HasColumnName("roleId");

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.AppUsers)
        //            .HasForeignKey(d => d.RoleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_APP_USERS_DCT_ROLES");
        //    });

        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.ToTable("DCT_ROLES");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.RoleName)
        //            .IsRequired()
        //            .HasColumnName("roleName")
        //            .HasMaxLength(20);
        //    });

        //    modelBuilder.Entity<Company>(entity =>
        //    {
        //        entity.ToTable("APP_COMPANIES");

        //        //entity.Property(e => e.Id)
        //        //    .HasColumnName("id")
        //        //    .ValueGeneratedNever();

        //        //entity.Property(e => e.Name)
        //        //    .IsRequired()
        //        //    .HasColumnName("Name")
        //        //    .HasMaxLength(40);
        //    });

        //    modelBuilder.Entity<JobApplication>(entity =>
        //    {
        //        entity.ToTable("APP_JOBAPPLICATIONS");

        //        //entity.Property(e => e.Id)
        //        //    .HasColumnName("id")
        //        //    .ValueGeneratedNever();

        //        //entity.Property(e => e.ContactAgreement)
        //        //    .IsRequired()
        //        //    .HasColumnName("ContactAgreement")
        //        //    .HasMaxLength(30);

        //        //entity.Property(e => e.LastName)
        //        //    .IsRequired()
        //        //    .HasColumnName("lastname")
        //        //    .HasMaxLength(20);

        //        //entity.Property(e => e.FirstName)
        //        //    .IsRequired()
        //        //    .HasColumnName("firstname")
        //        //    .HasMaxLength(20);

        //        //entity.Property(e => e.CVurl).HasColumnName("roleId")
        //        //    .IsRequired()
        //        //    .HasColumnName("CVurl");

        //        //entity.Property(e => e.EmailAddress).HasColumnName("email")
        //        //    .IsRequired()
        //        //    .HasColumnName("email");

        //        //entity.Property(e => e.JobOfferId).HasColumnName("email")
        //        //    .IsRequired()
        //        //    .HasColumnName("email");

        //    });
        //}
    }
}
