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

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
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
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// User repository.
        /// </param>
        /// <param name="orderRepository">
        /// Order repository.
        /// </param>
        public OrderService(
            IUserRepository userRepository,
            IOrderRepository orderRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
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
            var user = this.userRepository.GetUserWithOrdersByEmail(request.IdentityToken);
            if (user != null)
            {
                var order = request.ConvertToOrder();
                order.Retailer = new Retailer { Url = request.RetailerUrl, Name = request.RetailerUrl };
                var result = this.orderRepository.AddOrder(order);
                this.orderRepository.SaveChanges();
                user.AddOrder(result);
                this.orderRepository.SaveChanges();
                return result.ConvertToAddOrderResponse();
            }

            return null;
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

            var user = this.userRepository.GetUserWithOrdersByEmail(request.IdentityToken);
            if (user != null)
            {
                try
                {
                    var result = user.RemoveOrder(request.Id);
                    if (result)
                    {
                        this.orderRepository.RemoveOrder(request.Id);
                        this.orderRepository.SaveChanges();
                    }
                    else
                    {
                        response.MessageType = MessageType.Warning;
                        response.Message = "The order cannot be removed in current state.";
                    }
                }
                catch (Exception ex)
                {
                    response.MessageType = MessageType.Error;
                    response.Message = ex.Message;
                }
            }

            return response;
        }
    }
}