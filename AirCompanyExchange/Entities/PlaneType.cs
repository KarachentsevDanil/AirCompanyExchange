using Newtonsoft.Json;

namespace AirCompanyExchange.Entities
{
    [JsonObject(IsReference = true)]
    public class PlaneType
    {
        public int PlaneTypeId { get; set; }

        public string Name { get; set; }
    }
}
