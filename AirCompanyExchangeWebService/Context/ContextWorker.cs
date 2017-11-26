using AirCompanyExchange.Context;

namespace AirCompanyExchangeWebService.Context
{
    public class ContextWorker
    {
        public AirDbContext AirDbContext { get; set; }

        public ContextWorker()
        {
            AirDbContext = new AirDbContext();
        }
    }
}