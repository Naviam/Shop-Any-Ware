// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrdersIntegrationTests.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrdersIntegrationTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.Interfaces;
    using TdService.Services.ViewModels.Order;

    /// <summary>
    /// The orders integration tests.
    /// </summary>
    [TestFixture]
    public class OrdersIntegrationTests
    {
        /// <summary>
        /// Shop any ware context.
        /// </summary>
        private ShopAnyWareSql context;

        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// The order service.
        /// </summary>
        private IOrderService orderService;

        /// <summary>
        /// The order repository.
        /// </summary>
        private IOrderRepository orderRepository;

        /// <summary>
        /// The forms authentication.
        /// </summary>
        private IFormsAuthentication formsAuthentication;

        /// <summary>
        /// Setup everything for orders integration tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();

            this.formsAuthentication = new FakeFormsAuthentication();
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
            this.context = new ShopAnyWareSql();
            this.userRepository = new UserRepository(this.context);
            this.orderRepository = new OrderRepository(this.context);
            this.orderService = new OrderService(this.userRepository, this.orderRepository);
        }

        /// <summary>
        /// Should be able to view my recent orders.
        /// </summary>
        [Test]
        public void ShouldBeAbleToViewMyRecentOrders()
        {
            // arrange
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
            var controller = new OrderController(this.orderService, this.formsAuthentication);

            // act
            var actual = controller.GetRecent() as JsonResult;
            
            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as List<OrderViewModel>;
            Assert.That(model, Is.Not.Null);
            Debug.Assert(model != null, "model != null");
            Assert.That(model.Any(), Is.True);
        }

        /// <summary>
        /// Should be able to add new order.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAddNewOrder()
        {
            // arrange 
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
            var controller = new OrderController(this.orderService, this.formsAuthentication);
            var model = new OrderViewModel
                {
                    Id = 0,
                    RetailerName = "apple.com",
                    CreatedDate = DateTime.UtcNow,
                    ReceivedDate = null,
                    OrderNumber = null,
                    TrackingNumber = null,
                    Status = null
                };

            // act
            var actual = controller.AddOrder(model) as JsonResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var result = actual.Data as OrderViewModel;
            Assert.That(result, Is.Not.Null);
            Debug.Assert(result != null, "result != null");
            Assert.That(result.Id, Is.GreaterThan(0));
            Assert.That(result.RetailerName, Is.EqualTo("apple.com"));
            Assert.That(result.Status, Is.EqualTo("New"));
        }
    }
}