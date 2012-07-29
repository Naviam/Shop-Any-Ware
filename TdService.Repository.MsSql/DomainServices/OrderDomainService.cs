// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDomainService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order domain service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.DomainServices
{
    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Repository.MsSql.Repositories;

    /// <summary>
    /// The order domain service.
    /// </summary>
    public class OrderDomainService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The order repository.
        /// </summary>
        private readonly IOrderRepository orderRepository;

        /// <summary>
        /// The retailer repository.
        /// </summary>
        private readonly IRetailerRepository retailerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDomainService"/> class.
        /// </summary>
        public OrderDomainService()
        {
            var context = new ShopAnyWareSql();
            this.userRepository = new UserRepository(context);
            this.orderRepository = new OrderRepository(context);
            this.retailerRepository = new RetailerRepository(context);
        }

        public Order CreateOrder(string email, Order order)
        {
            return new Order();
        }
    }
}