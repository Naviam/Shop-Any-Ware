// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderServiceTests.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrderServiceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The order service tests.
    /// </summary>
    [TestFixture]
    public class OrderServiceTests
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// The order repository.
        /// </summary>
        private IOrderRepository orderRepository;

        /// <summary>
        /// Make necessary preparation to test order service.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var orders = new List<Order>
                {
                    new Order(OrderStatus.Received)
                        {
                            CreatedDate = DateTime.UtcNow,
                            CreatedBy = new User(),
                            DisposedDate = null,
                            Id = 0,
                            OrderNumber = "12212",
                            ReceivedDate = null,
                            Retailer = new Retailer("amazon.com"),
                            ReturnedDate = null
                        }
                };
            this.orderRepository = new FakeOrderRepository(orders);
            this.userRepository = new FakeUserRepository();
        }

        /// <summary>
        /// Should be able to get list of recent orders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetListOfOrders()
        {
            // arrange
            var service = new OrderService(this.userRepository, this.orderRepository);
            var request = new GetRecentOrdersRequest { IdentityToken = "vhatalski@naviam.com" };
            var expected = new List<GetRecentOrdersResponse>();

            // act
            var actual = service.GetRecent(request);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}