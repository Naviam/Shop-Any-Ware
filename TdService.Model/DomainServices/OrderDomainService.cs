namespace TdService.Model.DomainServices
{
    using System;
    using System.Linq;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;

    /// <summary>
    /// Order domain service.
    /// </summary>
    public class OrderDomainService
    {
        /// <summary>
        /// User repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Order repository.
        /// </summary>
        private readonly IOrderRepository orderRepository;

        /// <summary>
        /// Unit of work.
        /// </summary>
        private readonly IRetailerRepository retailerRepository;

        public OrderDomainService(
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            IRetailerRepository retailerRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.retailerRepository = retailerRepository;
        }

        /// <summary>
        /// Add new order to user.
        /// </summary>
        /// <param name="email">The email of an user.</param>
        /// <param name="shopNameOrUrl">The shop name or url.</param>
        public Order AddNewOrderToUser(string email, string shopNameOrUrl)
        {
            var user = this.userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new ArgumentException("The user has not been found in db by this email.", "email");
            }

            // get or create retailer
            var retailer = new Retailer(shopNameOrUrl);
            retailer = this.retailerRepository.FindOrAdd(retailer);
            this.retailerRepository.SaveChanges();

            // create new order
            var order = Order.CreateNew(retailer);
            order = this.orderRepository.AddOrder(order);
            this.orderRepository.SaveChanges();

            // attach created order to user
            user.AddOrder(order);
            this.userRepository.UpdateUser(user);
            this.userRepository.SaveChanges();

            return order;
        }

        /// <summary>
        /// Remove order from user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="order"></param>
        public void RemoveOrderFromUser(string email, Order order)
        {
            var user = this.userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new ArgumentException("The user has not been found in db by this email.", "email");
            }

            var orderDb = user.Orders.SingleOrDefault(o => o.Id == order.Id);
            user.RemoveOrder(orderDb);

            if (orderDb != null)
            {
                this.orderRepository.RemoveOrder(orderDb.Id);
                this.orderRepository.SaveChanges();
            }
        }
    }
}