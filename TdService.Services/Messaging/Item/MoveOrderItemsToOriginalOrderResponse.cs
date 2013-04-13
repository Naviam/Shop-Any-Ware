// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemsToOriginalOrderResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order items to original order response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The move order items to original order response.
    /// </summary>
    public class MoveOrderItemsToOriginalOrderResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<ItemResponse> Items { get; set; }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
