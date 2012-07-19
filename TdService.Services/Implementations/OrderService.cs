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
    using System.Collections.Generic;

    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
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
            var user = this.userRepository.GetUserByEmail(request.IdentityToken);
            if (user != null)
            {
                var recentOrders = user.GetRecentOrders();
                return recentOrders.ConvertToRecentOrdersResponseCollection();
            }

            return null;
        }
    }
}