// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangePackageDeliveryAddressResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change package delivery address response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The change package delivery address response.
    /// </summary>
    public class ChangePackageDeliveryAddressResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        public string CountryCode { get; set; }
    }
}
