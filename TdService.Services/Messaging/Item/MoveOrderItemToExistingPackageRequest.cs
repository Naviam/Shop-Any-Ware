// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemToExistingPackageRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order item to existing package request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The move order item to existing package request.
    /// </summary>
    public class MoveOrderItemToExistingPackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int ItemId { get; set; }
    }
}
