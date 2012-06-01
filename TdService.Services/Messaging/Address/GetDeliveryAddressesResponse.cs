// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDeliveryAddressesResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the GetDeliveryAddressesResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Get delivery addresses response object.
    /// </summary>
    public class GetDeliveryAddressesResponse
    {
        /// <summary>
        /// Gets or sets DeliveryAddressesView.
        /// </summary>
        public DeliveryAddressesView DeliveryAddressesView { get; set; }
    }
}