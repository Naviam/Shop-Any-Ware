namespace TdService.Model.Services
{
    using TdService.Infrastructure.UnitOfWork;
    using TdService.Model.Membership;
    using TdService.Model.Orders;

    /// <summary>
    /// Order domain service.
    /// </summary>
    public class OrderService
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
        private readonly IUnitOfWork unitOfWork;

        public OrderService(
            IUserRepository userRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add new order to user.
        /// </summary>
        /// <param name="email">The email of an user.</param>
        /// <param name="order">The order to add.</param>
        public void AddNewOrderToUser(string email, Order order)
        {
            var user = this.userRepository.GetUserByEmail(email);
            if (user != null)
            {
                this.orderRepository.AddOrder(order);
                user.AddOrder(order);
                this.unitOfWork.Commit();
            }
        }
    }
}