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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="retailerUrl">
        /// The retailer url.
        /// </param>
        /// <returns>
        /// The order.
        /// </returns>
        public Order CreateOrder(string email, string retailerUrl)
        {
            var user = this.userRepository.GetUserWithOrdersByEmail(email);
            if (user != null)
            {
                var retailer = new Retailer(retailerUrl);
                retailer = this.retailerRepository.FindOrAdd(retailer);
                this.retailerRepository.SaveChanges();

                var newOrder = Order.CreateNew(retailer);

                if (newOrder.GetBrokenRules().Any())
                {
                    var message = new StringBuilder();
                    foreach (var rule in newOrder.GetBrokenRules())
                    {
                        message.Append(rule.Rule);
                    }
                    throw new InvalidOrderException(message.ToString());
                }

                var orderResult = this.orderRepository.AddOrder(newOrder);
                this.orderRepository.SaveChanges();

                if (user.Orders == null)
                {
                    user.Orders = new List<Order> { orderResult };
                }
                else
                {
                    user.Orders.Add(orderResult);
                }

                this.orderRepository.SaveChanges();
                return orderResult;
            }

            return null;
        }
    }
}