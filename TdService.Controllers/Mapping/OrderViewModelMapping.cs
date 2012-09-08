namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Order;
    using TdService.UI.Web.ViewModels.Order;

    public static class OrderViewModelMapping
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

        /// <summary>
        /// Convert add order request to order view model.
        /// </summary>
        /// <param name="response">
        /// The add order response.
        /// </param>
        /// <returns>
        /// The order view model.
        /// </returns>
        public static OrderViewModel ConverToOrderViewModel(this AddOrderResponse response)
        {
            return Mapper.Map<AddOrderResponse, OrderViewModel>(response);
        }

        /// <summary>
        /// Convert order view model to add order request.
        /// </summary>
        /// <param name="model">
        /// The order view model.
        /// </param>
        /// <returns>
        /// The add order request.
        /// </returns>
        public static AddOrderRequest ConvertToAddOrderRequest(this OrderViewModel model)
        {
            return Mapper.Map<OrderViewModel, AddOrderRequest>(model);
        }
    }
}