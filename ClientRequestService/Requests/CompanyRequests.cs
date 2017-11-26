using System;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using ClientRequestService.Common;

namespace ClientRequestService.Requests
{
    public class CompanyRequests
    {
        private static string UserUrl = "/api/companies/";

        public static bool Login(Company loginModel)
        {
            try
            {
                ClientExtenctions.PostData(loginModel, string.Concat(UserUrl, "Login"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Register(Company company)
        {
            try
            {
                ClientExtenctions.PostData(company, string.Concat(UserUrl, "Register"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static UserViewModel GetCurrentUser()
        {
            return ClientExtenctions.GetResult<UserViewModel>(string.Concat(UserUrl, "GetCurrentUser"));
        }

        public static bool LogOff()
        {
            try
            {
                ClientExtenctions.Post(string.Concat(UserUrl, "LogOff"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
