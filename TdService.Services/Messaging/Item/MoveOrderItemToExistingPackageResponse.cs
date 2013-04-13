// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemToExistingPackageResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order item to existing package response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The move order item to existing package response.
    /// </summary>
    public class MoveOrderItemToExistingPackageResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public ItemResponse Item { get; set; }

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
