// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TdService.Infrastructure.Logging;
    using TdService.Model.Common;
    using TdService.Model.Orders;
    using TdService.Resources;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The order service.
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Order repository.
        /// </summary>
        private readonly IOrderRepository orderRepository;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">
        /// Order repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public OrderService(IOrderRepository orderRepository, ILogger logger)
        {
            this.orderRepository = orderRepository;
            this.logger = logger;
        }

        /// <summary>
        /// Get recent orders (new or received within 30 days)
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <returns>
        /// The response message.
        /// </returns>
        public List<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request)
        {
            var recentOrders = this.orderRepository.GetMyRecent(request.IdentityToken);
            return recentOrders.ConvertToRecentOrdersResponseCollection();
        }

        /// <summary>
        /// The get history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of response messages.
        /// </returns>
        public List<GetRecentOrdersResponse> GetHistory(GetRecentOrdersRequest request)
        {
            var history = this.orderRepository.GetMyHistory(request.IdentityToken);
            return history.ConvertToRecentOrdersResponseCollection();
        }

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="request">
        /// The add new order request.
        /// </param>
        /// <returns>
        /// The add order response.
        /// </returns>
        public AddOrderResponse AddOrder(AddOrderRequest request)
        {
            var retailer = new Retailer(request.RetailerUrl);
            var newOrder = new Order(OrderStatus.New) { CreatedDate = DateTime.UtcNow, Retailer = retailer };
            var response = new AddOrderResponse { BrokenRules = retailer.GetBrokenRules().ToList() };
            response.BrokenRules.AddRange(newOrder.GetBrokenRules().ToList());
            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                return response;
            }

            try
            {
                var orderResult = this.orderRepository.AddOrder(request.IdentityToken, newOrder);
                response = orderResult.ConvertToAddOrderResponse();
                response.Message = CommonResources.OrderAddSuccessMessage;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.OrderAddErrorMessage;
                this.logger.Error(CommonResources.OrderAddErrorMessage, e);
            }

            return response;
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="request">
        /// Remove order request.
        /// </param>
        /// <returns>
        /// Remove order response.
        /// </returns>
        public RemoveOrderResponse RemoveOrder(RemoveOrderRequest request)
        {
            var response = new RemoveOrderResponse();

            try
            {
                var order = this.orderRepository.RemoveOrder(request.IdentityToken, request.Id);
                response = order.ConvertToRemoveOrderResponse();
            }
            catch (Exception ex)
            {
                response.Id = request.Id;
                response.MessageType = MessageType.Error;
                response.ErrorCode = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// The update order.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.UpdateOrderResponse.
        /// </returns>
        public UpdateOrderResponse UpdateOrder(UpdateOrderRequest request)
        {
            OrderStatus orderStatus;
            Enum.TryParse(request.Status, true, out orderStatus);
            var order = new Order(orderStatus)
                {
                    Id = request.Id,
                    CreatedDate = DateTime.UtcNow,
                    OrderNumber = request.OrderNumber,
                    TrackingNumber = request.TrackingNumber
                };
            var response = new UpdateOrderResponse { BrokenRules = order.GetBrokenRules().ToList() };
            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                return response;
            }

            try
            {
                var orderToUpdate = this.orderRepository.GetOrderById(order.Id);
                orderToUpdate.OrderNumber = order.OrderNumber;
                orderToUpdate.TrackingNumber = order.TrackingNumber;
                var updatedOrder = this.orderRepository.UpdateOrder(order);
                response = updatedOrder.ConvertToUpdateOrderResponse();
                response.Message = CommonResources.OrderUpdateSuccessMessage;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.OrderUpdateErrorMessage;
                this.logger.Error(CommonResources.OrderUpdateErrorMessage, e);
            }

            return response;
        }
    }
}