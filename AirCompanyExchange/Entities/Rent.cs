using System.Collections.Generic;

namespace AirCompanyExchange.Entities
{
    public class Rent
    {
        public int RentId { get; set; }

        public int CompanyId { get; set; }

        public int CountFlights { get; set; }

        public string Feedback { get; set; }

        public virtual Company Company { get; set; }

        public ICollection<RentPlane> Planes { get; set; }
    }
}
