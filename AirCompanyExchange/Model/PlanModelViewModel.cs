using System.Collections.Generic;
using AirCompanyExchange.Entities;

namespace AirCompanyExchange.Model
{
    public class PlaneModelViewModel : PlaneModel
    {
        public IEnumerable<PlaneType> PlaneTypes { get; set; }
    }
}
