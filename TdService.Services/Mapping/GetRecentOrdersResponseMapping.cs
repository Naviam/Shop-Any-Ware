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
        public static IEnumerable<OrderViewModel> ConvertToOrderViewModelCollection(this IEnumerable<GetRecentOrdersResponse> getRecentOrdersResponseCollection)
        {
            Mapper.CreateMap<IEnumerable<GetRecentOrdersResponse>, IEnumerable<OrderViewModel>>();
            return Mapper.Map<IEnumerable<GetRecentOrdersResponse>, IEnumerable<OrderViewModel>>(getRecentOrdersResponseCollection);
        }
    }
}