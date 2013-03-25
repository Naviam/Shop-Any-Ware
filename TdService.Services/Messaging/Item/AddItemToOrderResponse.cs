// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddItemToOrderResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add item to order response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The add item to order response.
    /// </summary>
    public class AddItemToOrderResponse : ItemResponse
    {
        public int OrderId { get; set; }
    }
}