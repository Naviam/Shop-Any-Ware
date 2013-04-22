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
    using Rhino.Mocks;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Orders;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;
    using TdService.ShopAnyWare.Tests.Mocks;
    using TdService.UI.Web;

    /// <summary>
    /// The order service tests.
    /// </summary>
    [TestFixture]
    public class OrderServiceTests
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Make necessary preparation to test order service.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();

            this.logger = new DummyLogger();
        }

        /// <summary>
        /// Should be able to add new order to the list of user orders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAddNewOrder()
        {
            // arrange
            var mock = new MockRepository();
            var repository = mock.DynamicMock<IOrderRepository>();
            const string IdentityToken = "vhatalski@naviam.com";
            const string RetailerUrl = "amazon.com";
            Expect.Call(repository.AddOrder(IdentityToken, new Order { Retailer = new Retailer(RetailerUrl) }))
                .Return(new Order(OrderStatus.New) { Retailer = new Retailer(RetailerUrl), CreatedDate = DateTime.UtcNow });
            var service = new OrderService(repository, new FakeEmailService(), this.logger);
            var request = new AddOrderRequest
                {
                    IdentityToken = IdentityToken,
                    RetailerUrl = RetailerUrl,
                    CreatedDate = DateTime.UtcNow
                };

            // act
            mock.ReplayAll();
            var actual = service.AddOrder(request);
            mock.VerifyAll();

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.CreatedDate, Is.EqualTo(request.CreatedDate).Within(1).Minutes);
            Assert.That(actual.RetailerUrl, Is.EqualTo(request.RetailerUrl));
        }

        /// <summary>
        /// Should be able to get list of recent orders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetListOfOrders()
        {
            // arrange
            var mock = new MockRepository();
            var repository = mock.StrictMock<IOrderRepository>();
            const string IdentityToken = "vhatalski@naviam.com";
            Expect.Call(repository.GetMyRecent(IdentityToken)).Return(
                new List<Order>
                {
                    new Order(OrderStatus.New)
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 1,
                            OrderNumber = "12212",
                            ReceivedDate = null,
                            Retailer = new Retailer("amazon.com"),
                            ReturnedDate = null
                        },
                    new Order(OrderStatus.Received)
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 2,
                            OrderNumber = "122122",
                            ReceivedDate = DateTime.UtcNow,
                            Retailer = new Retailer("apple.com"),
                            ReturnedDate = null
                        },
                    new Order(OrderStatus.ReturnRequested)
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 3,
                            OrderNumber = "1221227776",
                            ReceivedDate = DateTime.UtcNow,
                            Retailer = new Retailer("apple.com"),
                            ReturnedDate = null
                        }
                });
            var service = new OrderService(repository, new FakeEmailService(), this.logger);
            var request = new GetMyOrdersRequest { IdentityToken = IdentityToken };
            var expected = new List<GetMyOrdersResponse>
                {
                    new GetMyOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 1,
                            OrderNumber = "12212",
                            ReceivedDate = null,
                            RetailerUrl = "amazon.com",
                            ReturnedDate = null,
                            Status = "New"
                        },
                    new GetMyOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 2,
                            OrderNumber = "122122",
                            ReceivedDate = DateTime.UtcNow,
                            RetailerUrl = "apple.com",
                            ReturnedDate = null,
                            Status = "Received"
                        },
                    new GetMyOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            Id = 3,
                            OrderNumber = "1221227776",
                            ReceivedDate = DateTime.UtcNow,
                            RetailerUrl = "apple.com",
                            ReturnedDate = null,
                            Status = "ReturnRequested"
                        }
                };

            // act
            mock.ReplayAll();
            var actual = service.GetRecent(request);
            mock.VerifyAll();

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
        public void ShouldBeAbleToRemoveOrder()
        {
            // arrange
            var mock = new MockRepository();
            var repository = mock.StrictMock<IOrderRepository>();
            const string IdentityToken = "vhatalski@naviam.com";
            const int OrderId = 1;
            Expect.Call(repository.RemoveOrder(IdentityToken, OrderId)).Return(new Order { Id = 1 });
            var service = new OrderService(repository,new FakeEmailService(), this.logger);
            var request = new RemoveOrderRequest { IdentityToken = IdentityToken, Id = OrderId };

            // act
            mock.ReplayAll();
            var actual = service.RemoveOrder(request);
            mock.VerifyAll();

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.MessageType, Is.EqualTo(MessageType.Success));
        }

        /// <summary>
        /// Should be able to remove order in other state than new.
        /// </summary>
        [Test]
        public void ShouldNotBeAbleToRemoveOrderInStateOtherThanNew()
        {
            // arrange
            var mock = new MockRepository();
            var repository = mock.StrictMock<IOrderRepository>();
            const string IdentityToken = "vhatalski@naviam.com";
            const int OrderId = 2;
            Expect.Call(repository.RemoveOrder(IdentityToken, OrderId)).Throw(new ArgumentException());
            var service = new OrderService(repository, new FakeEmailService(), this.logger);
            var request = new RemoveOrderRequest { IdentityToken = IdentityToken, Id = OrderId };

            // act
            mock.ReplayAll();
            var actual = service.RemoveOrder(request);
            mock.VerifyAll();

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.MessageType, Is.EqualTo(MessageType.Error));
        }
    }
}