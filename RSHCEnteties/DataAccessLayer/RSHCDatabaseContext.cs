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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            ConfigureOfficeLocationsLiteraTable(modelBuilder.Entity<OfficeLocation>());
            ConfigurePersonsLiteraTable (modelBuilder.Entity<Person>());
            ConfigureLicensesLiteraTable (modelBuilder.Entity<License>());

            ConfigureIdentityUserLoginTable(modelBuilder.Entity<IdentityUserLogin>());
            ConfigureIdentityUserRoleTable(modelBuilder.Entity<IdentityUserRole>());
            ConfigureApplicationUserTable(modelBuilder.Entity<ApplicationUser>());
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
