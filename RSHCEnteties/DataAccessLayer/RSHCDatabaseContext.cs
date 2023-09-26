using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RSHCEnteties;

using System.Data.Common;
using System.Data.Entity.ModelConfiguration;
using System.Reflection.Emit;

using Microsoft.AspNet.Identity.EntityFramework;
using RSHCEnteties.Enteties;

namespace RSHCEnteties.DataAccessLayer
{
    public class RSHCDatabaseContext: DbContext
    {
        public RSHCDatabaseContext() : base("RSHCDatabaseContext") { }

        public virtual DbSet<OfficeLocation> OfficeLocations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }
        public virtual DbSet<IdentityUserRole> IdentityUserRoles { get; set; }
        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }


        public virtual DbSet<RSHCDevice> RSHCDevice { get; set; }
        public virtual DbSet<RSHCEmployee> RSHCEmployee { get; set; }
        public virtual DbSet<RSHCDeviceAssigment> RSHCDeviceAssigment { get; set; }


        public virtual DbSet<RSHCOnBoarding> RSHCOnBoarding { get; set; }
        public virtual DbSet<RSHCOffBoarding> RSHCOffBoarding { get; set; }

        public virtual DbSet<RSHCPhone> RSHCPhone { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            ConfigureOfficeLocationsLiteraTable(modelBuilder.Entity<OfficeLocation>());
            ConfigurePersonsLiteraTable (modelBuilder.Entity<Person>());
            ConfigureLicensesLiteraTable (modelBuilder.Entity<License>());

            ConfigureIdentityUserLoginTable(modelBuilder.Entity<IdentityUserLogin>());
            ConfigureIdentityUserRoleTable(modelBuilder.Entity<IdentityUserRole>());
            ConfigureApplicationUserTable(modelBuilder.Entity<ApplicationUser>());

            ConfigureRSHCDeviceTable(modelBuilder.Entity<RSHCDevice>());

            ConfigureRSHCEmployeeTable(modelBuilder.Entity<RSHCEmployee>());

            ConfigureRSHCDeviceAssigmentTable(modelBuilder.Entity<RSHCDeviceAssigment>());

            ConfigureRSHCOnBoardingTable(modelBuilder.Entity<RSHCOnBoarding>());
            ConfigureRSHCOffBoardingTable(modelBuilder.Entity<RSHCOffBoarding>());

            ConfigureRSHCPhoneTable(modelBuilder.Entity<RSHCPhone>());
        }

        private void ConfigureRSHCPhoneTable(EntityTypeConfiguration<RSHCPhone> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);
            modelBuilder.HasOptional(e => e.RSHCEmployee)
            .WithOptionalPrincipal()
            .Map(e => e.MapKey("RSHCEmployeeId"));
        }

        private void ConfigureRSHCOnBoardingTable(EntityTypeConfiguration<RSHCOnBoarding> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);
            modelBuilder.HasRequired(r => r.RSHCEmployee).WithMany().HasForeignKey(k => k.RSHCEmployeeId);
        }

        private void ConfigureRSHCOffBoardingTable(EntityTypeConfiguration<RSHCOffBoarding> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);
            modelBuilder.HasRequired(r => r.RSHCEmployee).WithMany().HasForeignKey(k => k.RSHCEmployeeId);
        }

        private void ConfigureRSHCDeviceAssigmentTable(EntityTypeConfiguration<RSHCDeviceAssigment> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);
            modelBuilder.HasRequired(r => r.RSHCDevice).WithMany().HasForeignKey(k => k.RSHCDeviceId);
            modelBuilder.HasRequired(r => r.RSHCEmployee).WithMany().HasForeignKey(k => k.RSHCEmployeeId);
        }

        private void ConfigureRSHCEmployeeTable(EntityTypeConfiguration<RSHCEmployee> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);
            modelBuilder.HasRequired(r => r.OfficeLocation).WithMany().HasForeignKey(k => k.OfficeLocationID);
            modelBuilder.HasOptional(o => o.RSHCOffBoarding)
            .WithOptionalPrincipal()
            .Map(o => o.MapKey("RSHCOffBoardingID"));
            modelBuilder.HasOptional(o => o.RSHCOnBoarding)
            .WithOptionalPrincipal()
            .Map(o => o.MapKey("RSHCOnBoardingID"));
            modelBuilder.HasOptional(o => o.RSHCPhone)
            .WithOptionalPrincipal()
            .Map(o => o.MapKey("RSHCPhoneID"));

        }

        private void ConfigureRSHCDeviceTable(EntityTypeConfiguration<RSHCDevice> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.ID);               
        }

        private void ConfigureIdentityUserRoleTable(EntityTypeConfiguration<IdentityUserRole> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.UserId);
        }

        private void ConfigureIdentityUserLoginTable(EntityTypeConfiguration<IdentityUserLogin> modelBuilder)
        {
            modelBuilder.HasKey(buildAction => buildAction.UserId);
        }

        private void ConfigureApplicationUserTable(EntityTypeConfiguration<ApplicationUser> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);
        }

        private void ConfigureOfficeLocationsLiteraTable(EntityTypeConfiguration<OfficeLocation> modelBuilder)
        {

            modelBuilder
            .Property(e => e.OfficeValue)
            .IsUnicode(false);

            modelBuilder
                .HasMany(e => e.Persons)
                .WithOptional(e => e.OfficeLocation)
                .HasForeignKey(e => e.OfficeID);
        }


        private void ConfigurePersonsLiteraTable(EntityTypeConfiguration<Person> modelBuilder)
        {
            modelBuilder
                   .Property(e => e.UserID)
                   .IsUnicode(false);

            modelBuilder
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.MI)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.EMail)
                .IsUnicode(false);

            modelBuilder
                .HasMany(e => e.Licenses)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.OwnerID);
        }

        private void ConfigureLicensesLiteraTable(EntityTypeConfiguration<License> modelBuilder)
        {
            modelBuilder
            .Property(e => e.OwnerID)
               .IsUnicode(false);

            modelBuilder
            .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.Jurisdiction)
                .IsUnicode(false);

            modelBuilder
                .Property(e => e.License1)
                .IsUnicode(false);
        }
    }
}
