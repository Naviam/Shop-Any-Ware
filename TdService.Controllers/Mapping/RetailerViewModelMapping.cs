// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailerViewModelMapping.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The retailer view model mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Retailer;
    using TdService.UI.Web.ViewModels.Retailer;

    /// <summary>
    /// The retailer view model mapping.
    /// </summary>
    public static class RetailerViewModelMapping
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
    }
}
