namespace TdService.Services.Implementations
{
    using System.Collections.Generic;

    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Order;

    public class OrderService : IOrderService
    {
        /// <summary>
        /// Order repository.
        /// </summary>
        private readonly IOrderRepository orderRepository;

        private readonly IUserRepository userRepository;

        /// <summary>
        /// Order service constructor.
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
        public IEnumerable<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request)
        {
            var user = this.userRepository.GetUserByEmail(request.IdentityToken);
            if (user != null)
            {
                var recentOrders = user.GetRecentOrders();
            }

            return null;
        }
    }
}