// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShippingHelper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shipping helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    using DotNetShipping;
    using DotNetShipping.ShippingProviders;

    using SeeSharpShip.Models.Usps.International.Request;
    using SeeSharpShip.Services.Usps;

    /// <summary>
    /// The shipping helper.
    /// </summary>
    public class ShippingHelper
    {
        /// <summary>
        /// The get shipping rate.
        /// </summary>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public decimal GetShippingRate()
        {
            // You will need a userId to use the USPS provider. Your account will also need access to the production servers.
            const string UspsUserId = "852TRADE0543";

            var origin = new Address(string.Empty, string.Empty, "06405", "US");
            var destination = new Address(string.Empty, string.Empty, "121352", "RU"); // US Address

            // Create RateManager
            var rateManager = new RateManager();
            var provider = new USPSProvider(UspsUserId);

            rateManager.AddProvider(provider);

            // Call GetRates()
            var shipment = rateManager.GetRates(origin, destination, new Package(12, 12, 12, 35, 150));
            var rate = shipment.Rates[0];
            return rate.TotalCharges;
        }

        /// <summary>
        /// The get shipping rate.
        /// </summary>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public decimal GetShippingRate2()
        {
            var service = new RateService();
            var package = new InternationalPackage();
            package.Country = "Russia";
            package.OriginZip = "11201";
            package.Pounds = 2;
            package.Ounces = 1;
            var request = new IntlRateV2Request { UserId = "852TRADE0543" };
            service.Get(request);
        }
    }
}
