// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDeliveryAddressesRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the GetDeliveryAddressesRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    /// <summary>
    /// Get delivery addresses request object.
    /// </summary>
    public class GetDeliveryAddressesRequest
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }
    }
}