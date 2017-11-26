using System.Collections.Generic;

namespace AirCompanyExchange.Entities
{
    public class Plane
    {
        public int PlaneId { get; set; }

        public int CompanyId { get; set; }

        public int PlaneModelId { get; set; }

        public double CostPerFlight { get; set; }

        public virtual PlaneModel PlaneModel { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<RentPlane> Rents { get; set; }
    }
}
