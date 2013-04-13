// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPackageItemsResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get package items response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The get package items response.
    /// </summary>
    public class GetPackageItemsResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<ItemResponse> Items { get; set; }
    }
}