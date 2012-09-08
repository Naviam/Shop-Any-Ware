namespace TdService.UI.Web.Mapping
{
    using AutoMapper;
    using System.Collections.Generic;

    using TdService.Services.Messaging.Retailer;
    using TdService.UI.Web.ViewModels.Retailer;

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
