using System.Collections.Generic;
using AirCompanyExchange.Entities;

namespace AirCompanyExchange.Model
{
    public class PlaneViewModel : Plane
    {
        public int CountPlanes { get; set; }

        public int StartCountPlaces { get; set; }

        public int EndCountPlaces { get; set; }

        public IEnumerable<PlaneModel> PlaneModels { get; set; }
    }
}
