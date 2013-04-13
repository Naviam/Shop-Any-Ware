// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangePackageDeliveryAddressRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change package delivery address request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The change package delivery address request.
    /// </summary>
    public class ChangePackageDeliveryAddressRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the deliver address id.
        /// </summary>
        public int DeliverAddressId { get; set; }
    }
}
