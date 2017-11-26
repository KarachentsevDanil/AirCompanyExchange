using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using AirCompanyExchange.Entities;
using AirCompanyExchangeWebService.Context;

namespace AirCompanyExchangeWebService.Controllers
{
    public class RentsController : ApiController
    {
        private readonly ContextWorker _context;

        public RentsController()
        {
            _context = new ContextWorker();
        }

        public IEnumerable<Rent> GetRentsOfCompany(int companyId)
        {
            return _context.AirDbContext.Rents.Where(x => x.CompanyId == companyId).ToList();
        }

        public Rent GetRentDetailsById(int rentId)
        {
            return _context.AirDbContext.Rents.FirstOrDefault(x => x.RentId == rentId);
        }

        [HttpPost]
        public void AddRent([FromBody] Rent rent)
        {
            _context.AirDbContext.Rents.Add(rent);
            _context.AirDbContext.SaveChanges();
        }

        [HttpPost]
        public void CompleteRent([FromBody] Rent rentModel)
        {
            var rent = _context.AirDbContext.Rents.First(x => x.RentId == rentModel.RentId);

            rent.Feedback = rentModel.Feedback;
            rent.IsCompleated = rentModel.IsCompleated;

            _context.AirDbContext.Rents.AddOrUpdate(rent);
            _context.AirDbContext.SaveChanges();
        }
    }
}