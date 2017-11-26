using System;
using System.Collections.Generic;
using AirCompanyExchange.Entities;
using ClientRequestService.Common;

namespace ClientRequestService.Requests
{
    public class RentRequest
    {
        public const string RentUrl = "/api/rents/";

        public static bool AddRent(Rent rent)
        {
            try
            {
                ClientExtenctions.PostData(rent, string.Concat(RentUrl, "AddRent"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompleteRent(Rent rent)
        {
            try
            {
                ClientExtenctions.PostData(rent, string.Concat(RentUrl, "CompleteRent"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Rent GetRentDetailsById(int rentId)
        {
            return ClientExtenctions.GetResult<Rent>(string.Concat(RentUrl, $"GetRentDetailsById?rentId={rentId}"));
        }

        public static List<Rent> GetRentsOfCompany(int companyId)
        {
            return ClientExtenctions.GetResult<List<Rent>>(string.Concat(RentUrl, $"GetRentsOfCompany?companyId={companyId}"));
        }
    }
}
