using System;
using System.Collections.Generic;
using AirCompanyExchange.Entities;
using AirCompanyExchange.Model;
using ClientRequestService.Common;

namespace ClientRequestService.Requests
{
    public class PlaneRequests
    {
        public const string PlaneUrl = "/api/planes/";

        public static bool AddPlane(PlaneViewModel plane)
        {
            try
            {
                ClientExtenctions.PostData(plane, string.Concat(PlaneUrl, "AddPlane"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddPlaneModel(PlaneModel planeModel)
        {
            try
            {
                ClientExtenctions.PostData(planeModel, string.Concat(PlaneUrl, "AddPlaneModel"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<PlaneType> GetPlaneTypes()
        {
            return ClientExtenctions.GetResult<List<PlaneType>>(string.Concat(PlaneUrl, "GetPlaneTypes"));
        }

        public static List<PlaneModel> GetPlaneModels()
        {
            return ClientExtenctions.GetResult<List<PlaneModel>>(string.Concat(PlaneUrl, "GetPlaneModels"));
        }

        public static Plane GetPlaneById(int planeId)
        {
            return ClientExtenctions.GetResult<Plane>(string.Concat(PlaneUrl, $"GetPlaneById?planeId={planeId}"));
        }

        public static List<Plane> GetPlanesOfCompany(int companyId)
        {
            return ClientExtenctions.GetResult<List<Plane>>(string.Concat(PlaneUrl, $"GetPlanesOfCompany?companyId={companyId}"));
        }

        public static List<Plane> GetAvailablePlanes(PlaneViewModel model)
        {
            return ClientExtenctions.PostDataAndGetResult<PlaneViewModel, List<Plane>>(model, string.Concat(PlaneUrl, "GetAvailablePlanes"));
        }
    }
}
