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
    using TdService.Model.Membership;
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
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// User repository.
        /// </param>
        /// <param name="orderRepository">
        /// Order repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public OrderService(
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            ILogger logger)
        {
            this.userRepository = userRepository;
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
            var user = this.userRepository.GetUserWithOrdersByEmail(request.IdentityToken);
            if (user != null)
            {
                var recentOrders = user.GetRecentOrders();
                return recentOrders.ConvertToRecentOrdersResponseCollection();
            }

            return null;
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
            var response = new RemoveOrderResponse { MessageType = MessageType.Success };

            try
            {
                this.orderRepository.RemoveOrder(request.IdentityToken, request.Id);
            }
            catch (Exception ex)
            {
                response.MessageType = MessageType.Error;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}