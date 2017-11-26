using System.Collections.Generic;
using Newtonsoft.Json;

namespace AirCompanyExchange.Entities
{
    [JsonObject(IsReference = true)]
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
    }
}
