using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using AirCompanyExchangeWebService.Context;

namespace AirCompanyExchangeWebService.Controllers
{
    public class PlanesController : ApiController
    {
        private readonly ContextWorker _context;

        public PlanesController()
        {
            _context = new ContextWorker();
        }

        public List<PlaneType> GetPlaneTypes()
        {
            return _context.AirDbContext.PlaneTypes.ToList();
        }

        public List<PlaneModel> GetPlaneModels()
        {
            return _context.AirDbContext.PlaneModels.ToList();
        }

        public Plane GetPlaneById(int planeId)
        {
            return _context.AirDbContext.Planes.FirstOrDefault(x=> x.PlaneId == planeId);
        }

        public IEnumerable<Plane> GetPlanesOfCompany(int companyId)
        {
            return _context.AirDbContext.Planes.Where(x => x.CompanyId == companyId).ToList();
        }

        public IEnumerable<Plane> GetAvailablePlanes(PlaneViewModel planeView)
        {
            return _context.AirDbContext.Planes
                .Where(x =>
                    x.PlaneModel.Capacity >= planeView.StartCountPlaces &&
                    x.PlaneModel.Capacity <= planeView.EndCountPlaces &&
                    x.Rents.All(p=> p.Rent.IsCompleated))
                .ToList()
                .Take(planeView.CountPlanes)
                .ToList();
        }

        [HttpPost]
        public void AddPlane([FromBody] PlaneViewModel plane)
        {
            var planes = new List<Plane>(plane.CountPlanes);

            for (var i = 0; i < plane.CountPlanes; i++)
            {
                planes.Add(new Plane
                {
                    CompanyId = plane.CompanyId,
                    PlaneModelId = plane.PlaneModelId,
                    CostPerFlight = plane.CostPerFlight
                });
            }

            _context.AirDbContext.Planes.AddRange(planes);
            _context.AirDbContext.SaveChanges();
        }

        [HttpPost]
        public void AddPlaneModel([FromBody] PlaneModel planeModel)
        {
            _context.AirDbContext.PlaneModels.Add(planeModel);
            _context.AirDbContext.SaveChanges();
        }
    }
}