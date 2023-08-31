using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RSHCEnteties;


namespace RSHCEnteties.DataAccessLayer
{
    internal class RSHCDatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RSHCDatabaseContext>
    {
        protected override void Seed(RSHCDatabaseContext context)
        {
            //var licenses = new List<License>
            //{ 
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", },
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", },
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", },
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", },
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", },
            //    new License{OwnerID = "", Description = "", Jurisdiction = "", License1 = "", }
            //};
            //licenses.ForEach(l => context.Licenses.Add(l));
            //context.SaveChanges();
        }
    }
}
