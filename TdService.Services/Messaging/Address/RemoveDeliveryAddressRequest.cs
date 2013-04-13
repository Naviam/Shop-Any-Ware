// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveDeliveryAddressRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The remove delivery address request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    /// <summary>
    /// The remove delivery address request.
    /// </summary>
    public class RemoveDeliveryAddressRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}