using System.Collections.Generic;
using System.Data.Entity;
using AirCompanyExchange.Entities;

namespace AirCompanyExchange.Context
{
    public class AirDbInitializer : DropCreateDatabaseIfModelChanges<AirDbContext>
    {
        protected override void Seed(AirDbContext context)
        {
            IList<PlaneType> detaultPlaneTypes = new List<PlaneType>();

            detaultPlaneTypes.Add(new PlaneType { Name = "Passenger" });
            detaultPlaneTypes.Add(new PlaneType { Name = "Cargo" });
            detaultPlaneTypes.Add(new PlaneType { Name = "War-Plane" });

            foreach (var planeType in detaultPlaneTypes)
                context.PlaneTypes.Add(planeType);

            base.Seed(context);
        }
    }
}
