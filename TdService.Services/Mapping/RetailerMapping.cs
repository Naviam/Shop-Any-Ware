// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailerMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The retailer mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Common;
    using TdService.Services.Messaging.Retailer;

    /// <summary>
    /// The retailer mapping.
    /// </summary>
    public static class RetailerMapping
    {
        /// <summary>
        /// Convert the list of retailers to the list of retailer responses.
        /// </summary>
        /// <param name="retailers">
        /// The retailers collection.
        /// </param>
        /// <returns>
        /// The collection of get retailers responses.
        /// </returns>
        public static List<GetRetailersResponse> ConvertToGetRetailersResponseCollection(this List<Retailer> retailers)
        {
            return Mapper.Map<List<Retailer>, List<GetRetailersResponse>>(retailers);
        }
    }
}