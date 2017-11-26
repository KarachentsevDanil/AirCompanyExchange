using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCompanyExchange.Entities
{
    public class PlaneModel
    {
        public int PlaneModelId { get; set; }

        public int PlaneTypeId { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public virtual PlaneType PlaneType { get; set; }

        public ICollection<Plane> Planes { get; set; }
    }
}
