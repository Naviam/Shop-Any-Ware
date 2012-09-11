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
    using System.Text;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Resources.Views;
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
        /// The retailer repository.
        /// </summary>
        private readonly IRetailerRepository retailerRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// User repository.
        /// </param>
        /// <param name="orderRepository">
        /// Order repository.
        /// </param>
        /// <param name="retailerRepository">
        /// The retailer Repository.
        /// </param>
        public OrderService(
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            IRetailerRepository retailerRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.retailerRepository = retailerRepository;
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
            retailer = this.retailerRepository.FindOrAdd(retailer);
            this.retailerRepository.SaveChanges();

            var newOrder = new Order(OrderStatus.New) { CreatedDate = DateTime.UtcNow };
            if (newOrder.GetBrokenRules().Any())
            {
                var message = new StringBuilder();
                foreach (var rule in newOrder.GetBrokenRules())
                {
                    message.Append(rule.ErrorCode);
                }

                throw new InvalidOrderException(message.ToString());
            }

            var orderResult = this.orderRepository.AddOrder(newOrder);
            this.orderRepository.AttachRetailer(retailer);
            orderResult.Retailer = retailer;
            this.orderRepository.SaveChanges();

            this.userRepository.AttachOrder(request.IdentityToken, orderResult.Id);
            this.userRepository.SaveChanges();

            return orderResult.ConvertToAddOrderResponse();
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
                        response.Message = DashboardViewResources.OrderCannotBeRemoved;
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