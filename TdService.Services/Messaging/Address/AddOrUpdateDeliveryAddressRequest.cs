// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDeliveryAddressRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Add Or Update Delivery Address Request type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Add or update delivery address request.
    /// </summary>
    public class AddDeliveryAddressRequest
    {
        /// <summary>
        /// Gets or sets Delivery Addresses View.
        /// </summary>
        public DeliveryAddressesView DeliveryAddressesView { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }
    }
}