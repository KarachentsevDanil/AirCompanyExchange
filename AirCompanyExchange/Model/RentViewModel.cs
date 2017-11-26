using System.Collections.Generic;
using AirCompanyExchange.Entities;

namespace AirCompanyExchange.Model
{
    public class RentViewModel : Rent
    {
        public int CountPlanes { get; set; }

        public int StartCountPlaces { get; set; }

        public int EndCountPlaces { get; set; }

        public int PlaneTypeId { get; set; }

        public IEnumerable<PlaneType> PlaneTypes { get; set; }
    }
}
