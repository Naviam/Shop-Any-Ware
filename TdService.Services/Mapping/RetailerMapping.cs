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
    using TdService.Services.ViewModels.Retailer;

    /// <summary>
    /// The retailer mapping.
    /// </summary>
    public static class RetailerMapping
    {
        /// <summary>
        /// Convert the list of get retailers responses to the list of retailer view models.
        /// </summary>
        /// <param name="retailerResponses">
        /// The retailers responses.
        /// </param>
        /// <returns>
        /// The collection of retailer view models.
        /// </returns>
        public static List<RetailerViewModel> ConvertToRetailerViewModelCollection(this List<GetRetailersResponse> retailerResponses)
        {
            return Mapper.Map<List<GetRetailersResponse>, List<RetailerViewModel>>(retailerResponses);
        }

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