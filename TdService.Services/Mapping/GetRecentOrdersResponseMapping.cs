namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Order;
    using TdService.Services.ViewModels.Order;

    public static class GetRecentOrdersResponseMapping
    {
        /// <summary>
        /// Convert profile view to profile domain object.
        /// </summary>
        /// <param name="getRecentOrdersResponseCollection">
        /// The response messages collection.
        /// </param>
        /// <returns>
        /// Order view model collection.
        /// </returns>
        public static List<OrderViewModel> ConvertToOrderViewModelCollection(this List<GetRecentOrdersResponse> getRecentOrdersResponseCollection)
        {
            return Mapper.Map<List<GetRecentOrdersResponse>, List<OrderViewModel>>(getRecentOrdersResponseCollection);
        }
    }
}