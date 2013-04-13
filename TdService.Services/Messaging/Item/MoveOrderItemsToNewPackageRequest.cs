// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemsToNewPackageRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order items to new package request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The move order items to new package request.
    /// </summary>
    public class MoveOrderItemsToNewPackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        public string PackageName { get; set; }
    }
}
