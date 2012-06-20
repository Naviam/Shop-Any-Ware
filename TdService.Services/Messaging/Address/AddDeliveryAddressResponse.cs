// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDeliveryAddressResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Add Or Update Delivery Address Response
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Add Delivery Address Response
    /// </summary>
    public class AddDeliveryAddressResponse
    {
        /// <summary>
        /// Gets or sets DeliveryAddressView.
        /// </summary>
        public DeliveryAddressesView DeliveryAddressesView { get; set; }
    }
}