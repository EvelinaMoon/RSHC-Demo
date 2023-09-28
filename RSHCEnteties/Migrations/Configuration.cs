namespace RSHCEnteties.Migrations
{
    using RSHCEnteties.Enteties;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RSHCEnteties.DataAccessLayer.RSHCDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RSHCEnteties.DataAccessLayer.RSHCDatabaseContext context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var officeLocations = new List<OfficeLocation>

            {
                new OfficeLocation{ID = 1, OfficeValue ="Chicago", },
                new OfficeLocation{ID = 2, OfficeValue ="San Francisco", },
                new OfficeLocation{ID = 3, OfficeValue = "New York", },
                new OfficeLocation{ID = 4, OfficeValue = "Irvine", },
                new OfficeLocation{ID = 5, OfficeValue = "Ann Arbor", },
            };
            officeLocations.ForEach(l => context.OfficeLocations.Add(l));
            context.SaveChanges();

            var rshcDevices = new List<RSHCDevice>
            {
              new RSHCDevice  { SerialNumber = "TestNumber",  Name = "TestName", Brand ="TestBrand", BuildDate = DateTime.Today, ComputerName = "TestName", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes" },
              new RSHCDevice { SerialNumber = "TestNumber1",  Name = "TestName1",Brand = "TestBrand1", BuildDate = DateTime.Today.AddMonths(-6), ComputerName = "TestName1", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes1" },
              new RSHCDevice { SerialNumber = "TestNumber2",  Name = "TestName2", Brand = "TestBrand2", BuildDate = DateTime.Today.AddMonths(-6), ComputerName = "TestName2", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes2" },
            };
            rshcDevices.ForEach(d => context.RSHCDevice.Add(d));
            context.SaveChanges();

            var rshcEmployees = new List<RSHCEmployee>
            {
                new RSHCEmployee {  UserID = "TestRSHCEMail@RSHCEMail.com", AdmittedIn = DateTime.Today, DisplayName = "TestDisplayName", FirstName = "TestFirstName", LastName = "TestLastName", FullName = "TestFullName", MI = "TestMiddleName", RSHCEMail = "TestRSHCEMail@RSHCEMail.com", Initials = "TT", Title = RSHCTitle.IT, OfficeLocationID = 1, PrivateEMail = "PrivateEMail1@mail.com"},
                new RSHCEmployee { UserID = "TestRSHCEMail1@RSHCEMail.com", AdmittedIn = DateTime.Today.AddYears(-2), DisplayName = "TestDisplayName1", FirstName = "TestFirstName1", LastName = "TestLastName1", FullName = "TestFullName1", MI = "TestMiddleName1", RSHCEMail = "TestRSHCEMail1@RSHCEMail.com", Initials = "TT1", Title = RSHCTitle.IT, OfficeLocationID = 1,  PrivateEMail = "PrivateEMail2@mail.com"},
                new RSHCEmployee {  UserID = "TestRSHCEMail2@RSHCEMail.com", AdmittedIn = DateTime.Today.AddYears(-2), DisplayName = "TestDisplayName2", FirstName = "TestFirstName2", LastName = "TestLastName2", FullName = "TestFullName2", MI = "TestMiddleName2", RSHCEMail = "TestRSHCEMail2@RSHCEMail.com", Initials = "TT2", Title = RSHCTitle.IT, OfficeLocationID = 1,  PrivateEMail = "PrivateEMail3@mail.com"},
            };
            rshcEmployees.ForEach(e => context.RSHCEmployee.Add(e));
            context.SaveChanges();

            var rshcPhone = new List<RSHCPhone>
            {
                new RSHCPhone { Phone = "(847)499-4141", Extension = "4141", isAssigned = true, Status = RSHCPhoneStatus.Onsite, Tier = RSHCTier.Staff, TierDepartment = RSHCTierDepartment.IT, Notes = "Test note1", OfficeLocationID = 1, RSHCEMail = "rshc1@rshc-law.com", PreviousUsers = "Previous Users Test1",},
                new RSHCPhone {Phone = "(847)499-4142", Extension = "4142", isAssigned = true, Status = RSHCPhoneStatus.Onsite, Tier = RSHCTier.Staff, TierDepartment = RSHCTierDepartment.IT, Notes = "Test note2", OfficeLocationID = 1, RSHCEMail = "rshc2@rshc-law.com", PreviousUsers = "Previous Users Test2"},
                new RSHCPhone {Phone = "(847)499-4143", Extension = "4143", isAssigned = true, Status = RSHCPhoneStatus.Onsite, Tier = RSHCTier.Staff, TierDepartment = RSHCTierDepartment.IT, Notes = "Test note3", OfficeLocationID = 1, RSHCEMail = "rshc3@rshc-law.com", PreviousUsers = "Previous Users Test3"},
            };
            rshcPhone.ForEach(e => context.RSHCPhone.Add(e));
            context.SaveChanges();
        }
    }
}
