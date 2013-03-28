// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderControllerTests.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order controller tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using NUnit.Framework;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.ShopAnyWare.Tests.Account;
    using TdService.ShopAnyWare.Tests.Helpers;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Order;

    /// <summary>
    /// The order controller tests.
    /// </summary>
    [TestFixture]
    public class OrderControllerTests
    {
        /// <summary>
        /// The order service.
        /// </summary>
        private IOrderService orderService;

        /// <summary>
        /// The forms authentication.
        /// </summary>
        private IFormsAuthentication formsAuthentication;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();

            this.orderService = new FakeOrderService();
            this.formsAuthentication = new FakeFormsAuthentication();
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
        }

        /// <summary>
        /// This test verifies that only authorized users can access get recent orders method.
        /// </summary>
        [Category("Controller")]
        [Test(Description = "This test verifies that only authorized users can access getrecent orders method.")]
        public void ShouldBeAbleToCallGetRecentOrdersOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(OrdersController), "Recent", typeof(string));
        }

        /// <summary>
        /// This test verifies that get recent method returns JSON object with collection of orders that are within
        /// 30 days from received date.
        /// </summary>
        [Category("Controller")]
        [Test(Description = "This test verifies that getrecent method returns json object with collection of orders that are within 30 days from received date.")]
        public void ShouldReturnJsonCollectionOfRecentOrders()
        {
            // arrange
            var controller = new OrdersController(this.orderService, this.formsAuthentication);
            var currentDate = DateTime.UtcNow;
            var expected = new List<OrderViewModel>
                {
                    new OrderViewModel
                        {
                            Id = 1, 
                            CreatedDate = currentDate.AddDays(-30),
                            OrderNumber = "order number test 1",
                            ReceivedDate = currentDate.AddDays(-5),
                            TrackingNumber = "tracking number test 1",
                            RetailerUrl = "Amazon, Inc.",
                            Status = "Received"
                        }, 
                    new OrderViewModel
                        {
                            Id = 2, 
                            CreatedDate = currentDate.AddDays(-40), 
                            OrderNumber = "order number test 2", 
                            ReceivedDate = currentDate.AddDays(-25), 
                            TrackingNumber = "tracking number test 2", 
                            RetailerUrl = "Amazon, Inc.", 
                            Status = "Received"
                        }, 
                    new OrderViewModel
                        {
                            Id = 3, 
                            CreatedDate = currentDate.AddDays(-15), 
                            OrderNumber = "order number test 3", 
                            ReceivedDate = DateTime.MinValue, 
                            TrackingNumber = "tracking number test 3", 
                            RetailerUrl = "Amazon, Inc.", 
                            Status = "New"
                        }
                };

            // act
            var actual = controller.Recent(this.formsAuthentication.GetAuthenticationToken()) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                var actualOrders = (List<OrderViewModel>)actual.Data;
                for (var i = 0; i < expected.Count; i++)
                {
                    Assert.That(actualOrders[i].Id, Is.EqualTo(expected[i].Id));
                    Assert.That(actualOrders[i].CreatedDate, Is.EqualTo(expected[i].CreatedDate).Within(1).Minutes);
                    Assert.That(actualOrders[i].ReceivedDate, Is.EqualTo(expected[i].ReceivedDate).Within(1).Minutes);
                    Assert.That(actualOrders[i].RetailerUrl, Is.EqualTo(expected[i].RetailerUrl));
                    Assert.That(actualOrders[i].OrderNumber, Is.EqualTo(expected[i].OrderNumber));
                    Assert.That(actualOrders[i].TrackingNumber, Is.EqualTo(expected[i].TrackingNumber));
                    Assert.That(actualOrders[i].Status, Is.EqualTo(expected[i].Status));
                    Assert.That(actualOrders[i].CanBeRemoved, Is.EqualTo(expected[i].CanBeRemoved));
                }
            }
        }

        /// <summary>
        /// This test verifies that only authorized users can access add order method.
        /// </summary>
        [Category("Controller")]
        [Test]
        public void ShouldBeAbleToPostNewOrderOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(OrdersController), "Add", typeof(string), typeof(string));
        }

        /// <summary>
        /// This test verifies that new order can be created and returned with generated ID.
        /// </summary>
        [Category("Controller")]
        [Test]
        public void ShouldBeAbleToPostNewOrderAndGetOrderWithIdBack()
        {
            // arrange
            var controller = new OrdersController(this.orderService, this.formsAuthentication);
            var currentDate = DateTime.UtcNow;
            var expected = new OrderViewModel
                {
                    CreatedDate = currentDate,
                    ReceivedDate = null,
                    RetailerUrl = "amazon.com",
                    Id = 0,
                    OrderNumber = string.Empty,
                    Status = "New",
                    TrackingNumber = string.Empty
                };

            // act
            var actual = controller.Add(expected.RetailerUrl, this.formsAuthentication.GetAuthenticationToken()) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                var model = actual.Data as OrderViewModel;
                Assert.That(model, Is.Not.Null);
                Debug.Assert(model != null, "model != null");
                Assert.That(model.Id, Is.GreaterThan(0));
                Assert.That(model.CreatedDate, Is.EqualTo(currentDate).Within(1).Minutes);
                Assert.That(model.OrderNumber, Is.Null);
                Assert.That(model.TrackingNumber, Is.Null);
                Assert.That(model.Status, Is.EqualTo("New"));
            }
        }

        /// <summary>
        /// Should be able to call remove order method in controller only if authorized.
        /// </summary>
        [Category("Controller")]
        [Test]
        public void ShouldBeAbleToRemoveNewOrderOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(OrdersController), "Remove", typeof(int), typeof(string));
        }
    }
}