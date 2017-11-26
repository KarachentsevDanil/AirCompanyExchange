using System.Collections.Generic;
using System.Web.Mvc;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using AirCompanyExchangeWebApplication.Models;
using ClientRequestService.Requests;

namespace AirCompanyExchangeWebApplication.Controllers
{
    public class RentsController : Controller
    {
        public ActionResult AddRent()
        {
            var rentModel = new RentViewModel
            {
                PlaneTypes = PlaneRequests.GetPlaneTypes()
            };

            return View(rentModel);
        }

        public ActionResult CompleteRent(int rentId)
        {
            var rentModel = new RentViewModel
            {
                RentId = rentId
            };

            return View(rentModel);
        }

        [HttpPost]
        public ActionResult AddRent(RentViewModel rentModel)
        {
            var planes = PlaneRequests.GetAvailablePlanes(new PlaneViewModel
            {
                StartCountPlaces = rentModel.StartCountPlaces,
                EndCountPlaces = rentModel.EndCountPlaces,
                CountPlanes = rentModel.CountPlanes
            });

            rentModel.Planes = new List<RentPlane>(rentModel.CountPlanes);
            rentModel.CompanyId = CurrentUser.User.UserId;

            planes.ForEach(x => rentModel.Planes.Add(new RentPlane
            {
                PlaneId = x.PlaneId
            }));

            var isSuccess = RentRequest.AddRent(rentModel);
            if (!isSuccess || !ModelState.IsValid)
            {
                return View("AddRent");
            }

            return RedirectToAction("CompanyRents", "Rents");
        }

        [HttpPost]
        public ActionResult CompleteRent(RentViewModel rent)
        {
            var isSuccess = RentRequest.CompleteRent(rent);

            if (!isSuccess || !ModelState.IsValid)
            {
                return View("CompleteRent");
            }

            return RedirectToAction("CompanyRents", "Rents");
        }

        public ActionResult CompanyRents()
        {
            var rents = RentRequest.GetRentsOfCompany(CurrentUser.User.UserId);
            return View(rents);
        }

        public ActionResult RentDetails(int rentId)
        {
            var rent = RentRequest.GetRentDetailsById(rentId);
            return View(rent);
        }
    }
}