using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using AirCompanyExchangeWebService.Context;
using AirCompanyExchangeWebService.Models;

namespace AirCompanyExchangeWebService.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly ContextWorker _context;

        public CompaniesController()
        {
            _context = new ContextWorker();
        }

        [HttpPost]
        public bool Login([FromBody] Company company)
        {
            try
            {
                var companyModel = _context.AirDbContext.Companies.FirstOrDefault(x => x.Email == company.Email && x.Password == company.Password);

                if (companyModel != null)
                {
                    CurrentUser.User = new UserViewModel()
                    {
                        UserId = companyModel.CompanyId,
                        Name = companyModel.Name
                    };
                }

                return companyModel != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public UserViewModel Register([FromBody] Company company)
        {
            _context.AirDbContext.Companies.Add(company);
            _context.AirDbContext.SaveChanges();

            CurrentUser.User = new UserViewModel
            {
                UserId = company.CompanyId,
                Name = company.Name
            };

            return CurrentUser.User;
        }

        [HttpPost]
        public UserViewModel GetCurrentUser()
        {
            return CurrentUser.User;
        }

        [HttpPost]
        public void LogOff()
        {
            CurrentUser.User = null;
        }
    }
}