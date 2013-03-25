// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPackageItemsResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get package items response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The get package items response.
    /// </summary>
    public class GetPackageItemsResponse : ResponseBase
    {
        public List<ItemResponse> Items { get; set; }
    }
}