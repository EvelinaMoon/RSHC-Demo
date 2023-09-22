using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RSHCEnteties;
using RSHCEnteties.Enteties;

namespace RSHCEnteties.DataAccessLayer
{
    public class RSHCDatabaseInitializer : System.Data.Entity.CreateDatabaseIfNotExists<RSHCDatabaseContext>
    {
        protected override void Seed(RSHCDatabaseContext context)
        {
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
              new RSHCDevice  { Name = "TestName", Brand ="TestBrand", BuildDate = DateTime.Today, ComputerName = "TestName", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes" },
              new RSHCDevice { Name = "TestName1",Brand = "TestBrand1", BuildDate = DateTime.Today.AddMonths(-6), ComputerName = "TestName1", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes1" },
              new RSHCDevice { Name = "TestName2", Brand = "TestBrand2", BuildDate = DateTime.Today.AddMonths(-6), ComputerName = "TestName2", DeviceStatus = RSHCDeviceStatus.InStock, Notes = "TestNotes2" },
            };
            rshcDevices.ForEach(d => context.RSHCDevice.Add(d));
            context.SaveChanges();

            var rshcEmployees = new List<RSHCEmployee>
            {
                new RSHCEmployee {  UserID = "TestRSHCEMail@RSHCEMail.com", AdmittedIn = DateTime.Today, DisplayName = "TestDisplayName", FirstName = "TestFirstName", LastName = "TestLastName", FullName = "TestFullName", MI = "TestMiddleName", RSHCEMail = "TestRSHCEMail@RSHCEMail.com", Initials = "TT", Title = RSHCTitle.IT, OfficeLocationID = 1, },
                new RSHCEmployee { UserID = "TestRSHCEMail1@RSHCEMail.com", AdmittedIn = DateTime.Today.AddYears(-2), DisplayName = "TestDisplayName1", FirstName = "TestFirstName1", LastName = "TestLastName1", FullName = "TestFullName1", MI = "TestMiddleName1", RSHCEMail = "TestRSHCEMail1@RSHCEMail.com", Initials = "TT1", Title = RSHCTitle.IT, OfficeLocationID = 1, },
                new RSHCEmployee {  UserID = "TestRSHCEMail2@RSHCEMail.com", AdmittedIn = DateTime.Today.AddYears(-2), DisplayName = "TestDisplayName2", FirstName = "TestFirstName2", LastName = "TestLastName2", FullName = "TestFullName2", MI = "TestMiddleName2", RSHCEMail = "TestRSHCEMail2@RSHCEMail.com", Initials = "TT2", Title = RSHCTitle.IT, OfficeLocationID = 1, },
            };
            rshcEmployees.ForEach(e => context.RSHCEmployee.Add(e));
            context.SaveChanges();
        }
    }
}
