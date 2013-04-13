// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemsToExistingPackageRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order items to existing package request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The move order items to existing package request.
    /// </summary>
    public class MoveOrderItemsToExistingPackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
