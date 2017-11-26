using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AirCompanyExchange.Entities
{
    [JsonObject(IsReference = true)]
    public class RentPlane
    {
        [Key]
        [Column(Order = 0)]
        public int PlaneId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RentId { get; set; }

        public virtual Plane Plane { get; set; }

        public virtual Rent Rent { get; set; }
    }
}
