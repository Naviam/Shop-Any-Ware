using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SeeSharpShip.Models.Usps.International.Request;
using SeeSharpShip.Models.Usps.International.Response;
using SeeSharpShip.Services.Usps;

namespace TdService.Infrastructure.Usps
{
    public static class UspsRateCalculator
    {
        public static ShippingRatesResponse GetShippingRates(int weight, decimal height, decimal length, decimal width, decimal girth, string country, string valueOfContents)
        {
            var _rateService = new RateService(ConfigurationManager.AppSettings["UspsApiUrl"], new PostRequest());
            var _packages = new List<InternationalPackage>();
            _packages.Add(
                 new InternationalPackage
                 {
                     Pounds = weight,
                     Ounces = 0,
                     Machinable = false,
                     SelectedMailType = SeeSharpShip.Models.Usps.International.Request.MailType.Package,
                     Country = country,
                     Container = "RECTANGULAR",
                     Width = width,
                     Length = length,
                     Height = height,
                     Girth = girth,
                     Size = "Regular",
                     ValueOfContents = valueOfContents
                 });
            IntlRateV2Response resp;
            var response = new ShippingRatesResponse();
            try
            {
                resp =
                    _rateService.Get(
                        new IntlRateV2Request
                            {
                                Password = ConfigurationManager.AppSettings["UspsApiPwd"],
                                UserId = ConfigurationManager.AppSettings["UspsApiUserName"],
                                Packages = _packages,
                                Revision = "2"
                            });

                if (resp.Error != null)
                {
                    response.Error = resp.Error.Description;
                    return response;
                }

                var expressSvc = resp.Packages[0].Services.SingleOrDefault(s => s.Id.Equals("1"));
                if (expressSvc != null) response.ExpressMailPostagePrice = expressSvc.Postage;

                var prioritySvc = resp.Packages[0].Services.SingleOrDefault(s => s.Id.Equals("2"));
                if (prioritySvc != null) response.PriorityMailPostagePrice = prioritySvc.Postage;

                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                return response;
            }

        }
    }
}
