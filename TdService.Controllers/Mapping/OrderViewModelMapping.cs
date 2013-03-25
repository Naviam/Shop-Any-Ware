// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderViewModelMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order view model mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;
using AutoMapper;
using TdService.Services.Messaging.Item;
using TdService.Services.Messaging.Order;
using TdService.UI.Web.ViewModels.Order;

    /// <summary>
    /// The order view model mapping.
    /// </summary>
    public static class OrderViewModelMapping
    {
        /// <summary>
        /// Convert profile view to profile domain object.
        /// </summary>
        /// <param name="getMyOrdersResponses">
        /// The response messages collection.
        /// </param>
        /// <returns>
        /// Order view model collection.
        /// </returns>
        public static List<OrderViewModel> ConvertToOrderViewModelCollection(this List<GetMyOrdersResponse> getMyOrdersResponses)
        {
            return Mapper.Map<List<GetMyOrdersResponse>, List<OrderViewModel>>(getMyOrdersResponses);
        }

        /// <summary>
        /// The convert to order view model collection.
        /// </summary>
        /// <param name="getAllOrdersResponses">
        /// The get all orders responses.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.UI.Web.ViewModels.Order.OrderViewModel].
        /// </returns>
        public static List<OrderViewModel> ConvertToOrderViewModelCollection(this List<GetAllOrdersResponse> getAllOrdersResponses)
        {
            return Mapper.Map<List<GetAllOrdersResponse>, List<OrderViewModel>>(getAllOrdersResponses);
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
        /// The convert to order view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Order.OrderViewModel.
        /// </returns>
        public static OrderViewModel ConvertToOrderViewModel(this UpdateOrderResponse response)
        {
            return Mapper.Map<UpdateOrderResponse, OrderViewModel>(response);
        }

        /// <summary>
        /// The convert to order view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Order.OrderViewModel.
        /// </returns>
        public static OrderViewModel ConvertToOrderViewModel(this RemoveOrderResponse response)
        {
            return Mapper.Map<RemoveOrderResponse, OrderViewModel>(response);
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

        /// <summary>
        /// The convert to update order request.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.UpdateOrderRequest.
        /// </returns>
        public static UpdateOrderRequest ConvertToUpdateOrderRequest(this OrderViewModel model)
        {
            return Mapper.Map<OrderViewModel, UpdateOrderRequest>(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static OrderViewModel ConvertToOrderViewModel(this OrderReceivedResponse response)
        {
            return Mapper.Map<OrderReceivedResponse, OrderViewModel>(response);
        }
    }
}