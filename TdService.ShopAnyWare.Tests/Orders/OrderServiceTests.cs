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
    using TdService.Services.Messaging;
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
            AutoMapperConfiguration.Configure();

            var orders = new List<Order>
                {
                    new Order(OrderStatus.Received)
                        {
                            CreatedDate = DateTime.UtcNow,
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
        /// Should be able to add new order to the list of user orders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAddNewOrder()
        {
            // arrange
            var service = new OrderService(this.userRepository, this.orderRepository);
            var request = new AddOrderRequest
                {
                    IdentityToken = "vhatalski@naviam.com",
                    RetailerUrl = "apple.com",
                    CreatedDate = DateTime.UtcNow
                };

            // act
            var actual = service.AddOrder(request);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.CreatedDate, Is.EqualTo(request.CreatedDate));
            Assert.That(actual.RetailerUrl, Is.EqualTo(request.RetailerUrl));
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
            var expected = new List<GetRecentOrdersResponse>
                {
                    new GetRecentOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 0,
                            OrderNumber = "12212",
                            ReceivedDate = null,
                            RetailerUrl = "amazon.com",
                            ReturnedDate = null,
                            Status = "New"
                        },
                    new GetRecentOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 1,
                            OrderNumber = "122122",
                            ReceivedDate = DateTime.UtcNow,
                            RetailerUrl = "apple.com",
                            ReturnedDate = null,
                            Status = "Received"
                        }
                };

            // act
            var actual = service.GetRecent(request);

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                for (var i = 0; i < expected.Count; i++)
                {
                    Assert.That(actual[i].Id, Is.EqualTo(expected[i].Id));
                    Assert.That(actual[i].CreatedDate, Is.EqualTo(expected[i].CreatedDate).Within(1).Minutes);
                    Assert.That(actual[i].ReceivedDate, Is.EqualTo(expected[i].ReceivedDate).Within(1).Minutes);
                    Assert.That(actual[i].RetailerUrl, Is.EqualTo(expected[i].RetailerUrl));
                    Assert.That(actual[i].OrderNumber, Is.EqualTo(expected[i].OrderNumber));
                    Assert.That(actual[i].TrackingNumber, Is.EqualTo(expected[i].TrackingNumber));
                    Assert.That(actual[i].Status, Is.EqualTo(expected[i].Status));
                }
            }
        }

        /// <summary>
        /// Should be able to remove order in new status and that belongs to user.
        /// </summary>
        [Test]
        public void ShouldBeAbleToRemoveOrderOnlyIfInNewStatusAndBelongsToUser()
        {
            // arrange
            var service = new OrderService(this.userRepository, this.orderRepository);
            var request = new RemoveOrderRequest { IdentityToken = "vhatalski@naviam.com", Id = 1 };

            // act
            var actual = service.RemoveOrder(request);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.MessageType, Is.EqualTo(MessageType.Success));
        }
    }
}