// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddItemToOrderResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add item to order response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The add item to order response.
    /// </summary>
    public class AddItemToOrderResponse : ItemResponse
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public new int OrderId { get; set; }
    }
}