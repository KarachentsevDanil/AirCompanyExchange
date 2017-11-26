using System.Web.Mvc;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using AirCompanyExchangeWebApplication.Models;
using ClientRequestService.Requests;

namespace AirCompanyExchangeWebApplication.Controllers
{
    public class PlanesController : Controller
    {
        public ActionResult AddPlane()
        {
            var planeModel = new PlaneViewModel
            {
                PlaneModels = PlaneRequests.GetPlaneModels()
            };

            return View(planeModel);
        }

        public ActionResult AddPlaneModel()
        {
            var planeModel = new PlaneModelViewModel
            {
                PlaneTypes = PlaneRequests.GetPlaneTypes()
            };

            return View(planeModel);
        }

        [HttpPost]
        public ActionResult AddPlane(PlaneViewModel planeModel)
        {
            var isSuccess = PlaneRequests.AddPlane(planeModel);

            if (!isSuccess || !ModelState.IsValid)
            {
                return View("AddPlane");
            }

            return RedirectToAction("CompanyPlanes", "Planes");
        }

        [HttpPost]
        public ActionResult AddPlaneModel(PlaneModel planeModel)
        {
            var isSuccess = PlaneRequests.AddPlaneModel(planeModel);

            if (!isSuccess || !ModelState.IsValid)
            {
                return View("AddPlaneModel");
            }

            return RedirectToAction("AddPlane", "Planes");
        }

        public ActionResult CompanyPlanes()
        {
            var planes = PlaneRequests.GetPlanesOfCompany(CurrentUser.User.UserId);
            return View(planes);
        }

        public ActionResult PlaneDetails(int planeId)
        {
            var plane = PlaneRequests.GetPlaneById(planeId);
            return View(plane);
        }
    }
}