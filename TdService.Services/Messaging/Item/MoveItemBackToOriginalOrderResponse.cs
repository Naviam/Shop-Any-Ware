// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveItemBackToOriginalOrderResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move item back to original order response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The move item back to original order response.
    /// </summary>
    public class MoveItemBackToOriginalOrderResponse : ResponseBase
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
