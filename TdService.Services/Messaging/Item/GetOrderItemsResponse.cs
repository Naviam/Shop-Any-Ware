// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOrderItemsResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get order items response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The get order items response.
    /// </summary>
    public class GetOrderItemsResponse : ItemResponse
    {
        public class ItemImageModel
        {
            public string Url { get; set; }
            public string FileName { get; set; }
        }


        /// <summary>
        /// Gets or sets images
        /// </summary>
        public List<ItemImageModel> Images { get; set; }
    }
}