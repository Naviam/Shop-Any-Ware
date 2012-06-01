// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddOrUpdateDeliveryAddressRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AddOrUpdateDeliveryAddressRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    using TdService.Model.Addresses;

    /// <summary>
    /// Add or update delivery address request.
    /// </summary>
    public class AddOrUpdateDeliveryAddressRequest
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public DeliveryAddress Address { get; set; }
    }
}