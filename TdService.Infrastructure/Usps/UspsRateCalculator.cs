// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UspsRateCalculator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The USPS rate calculator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Usps
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using SeeSharpShip.Models.Usps.International.Request;
    using SeeSharpShip.Services.Usps;

    /// <summary>
    /// The USPS rate calculator.
    /// </summary>
    public static class UspsRateCalculator
    {
        /// <summary>
        /// The get shipping rates.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="girth">
        /// The girth.
        /// </param>
        /// <param name="country">
        /// The country.
        /// </param>
        /// <param name="valueOfContents">
        /// The value of contents.
        /// </param>
        /// <returns>
        /// The <see cref="ShippingRatesResponse"/>.
        /// </returns>
        public static ShippingRatesResponse GetShippingRates(int weight, decimal height, decimal length, decimal width, decimal girth, string country, string valueOfContents)
        {
            var rateService = new RateService(ConfigurationManager.AppSettings["UspsApiUrl"], new PostRequest());
            var packages = new List<InternationalPackage>
                               {
                                   new InternationalPackage
                                       {
                                           Pounds = weight,
                                           Ounces = 0,
                                           Machinable = false,
                                           SelectedMailType =
                                               MailType.Package,
                                           Country = country,
                                           Container = "RECTANGULAR",
                                           Width = width,
                                           Length = length,
                                           Height = height,
                                           Girth = girth,
                                           Size = "Regular",
                                           ValueOfContents =
                                               valueOfContents
                                       }
                               };
            var response = new ShippingRatesResponse();
            try
            {
                var resp = rateService.Get(
                    new IntlRateV2Request
                        {
                            Password = ConfigurationManager.AppSettings["UspsApiPwd"],
                            UserId = ConfigurationManager.AppSettings["UspsApiUserName"],
                            Packages = packages,
                            Revision = "2"
                        });

                if (resp.Error != null)
                {
                    response.Error = resp.Error.Description;
                    return response;
                }

                var expressSvc = resp.Packages[0].Services.SingleOrDefault(s => s.Id.Equals("1"));
                if (expressSvc != null)
                {
                    response.ExpressMailPostagePrice = expressSvc.Postage;
                }

                var prioritySvc = resp.Packages[0].Services.SingleOrDefault(s => s.Id.Equals("2"));
                if (prioritySvc != null)
                {
                    response.PriorityMailPostagePrice = prioritySvc.Postage;
                }

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
