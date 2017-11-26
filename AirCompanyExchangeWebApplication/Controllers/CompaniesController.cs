using System.Web.Mvc;
using AirCompanyExchange.Entities;
using AirCompanyExchangeWebApplication.Models;
using ClientRequestService.Requests;

namespace AirCompanyExchangeWebApplication.Controllers
{
    public class CompaniesController : Controller
    {
        public ActionResult Login()
        {
            CompanyRequests.LogOff();
            CurrentUser.User = null;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Company loginModel)
        {
            var isSuccess = CompanyRequests.Login(loginModel);

            if (!isSuccess || !ModelState.IsValid)
            {
                return View("Login");
            }

            CurrentUser.User = CompanyRequests.GetCurrentUser();

            return RedirectToAction("CompanyPlanes", "Planes");
        }

        [HttpPost]
        public ActionResult Register(Company company)
        {
            var isSuccess = CompanyRequests.Register(company);

            if (!isSuccess || !ModelState.IsValid)
            {
                return View("Login");
            }

            CurrentUser.User = CompanyRequests.GetCurrentUser();

            return RedirectToAction("CompanyPlanes", "Planes");
        }
    }
}