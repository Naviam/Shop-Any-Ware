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
    using System.Web.Mvc;

    using AutoMapper;

    using NUnit.Framework;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Order;
    using TdService.Services.ViewModels.Order;
    using TdService.ShopAnyWare.Tests.Account;
    using TdService.ShopAnyWare.Tests.Helpers;

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
        }

        /// <summary>
        /// The should map get recent order response to order view model.
        /// </summary>
        [Category("Controller")]
        [Test]
        public void ShouldMapGetRecentOrderResponseToOrderViewModel()
        {
            // Mapper.CreateMap<IEnumerable<GetRecentOrdersResponse>, IEnumerable<OrderViewModel>>();
            Mapper.CreateMap<GetRecentOrdersResponse, OrderViewModel>();

            var response = new GetRecentOrdersResponse
                {
                    CreatedDate = DateTime.UtcNow,
                    ReceivedDate = DateTime.UtcNow,
                    RetailerName = string.Empty,
                    Id = 1,
                    OrderNumber = string.Empty,
                    TrackingNumber = string.Empty,
                    Status = string.Empty
                };
            try
            {
                Mapper.Map<GetRecentOrdersResponse, OrderViewModel>(response);
            }
            catch (AutoMapperConfigurationException ex)
            {
                Assert.Fail(ex.Message);
            }

            var collection = new List<GetRecentOrdersResponse>
                {
                    new GetRecentOrdersResponse
                        {
                            CreatedDate = DateTime.UtcNow,
                            ReceivedDate = DateTime.UtcNow,
                            RetailerName = string.Empty,
                            Id = 1,
                            OrderNumber = string.Empty,
                            TrackingNumber = string.Empty,
                            Status = string.Empty
                        }
                };

            try
            {
                var orderViewModels = Mapper.Map<List<GetRecentOrdersResponse>, List<OrderViewModel>>(collection);
            }
            catch (AutoMapperMappingException ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.Pass();
        }

        /// <summary>
        /// This test verifies that only authorized users can access getrecent orders method.
        /// </summary>
        [Category("Controller")]
        [Test(Description = "This test verifies that only authorized users can access getrecent orders method.")]
        public void ShouldBeAbleToCallGetRecentOrdersOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(OrderController), "GetRecent");
        }

        /// <summary>
        /// This test verifies that getrecent method returns json object with collection of orders that are within
        /// 30 days from received date.
        /// </summary>
        [Category("Controller")]
        [Test(Description = "This test verifies that getrecent method returns json object with collection of orders that are within 30 days from received date.")]
        public void ShouldReturnJsonCollectionOfRecentOrders()
        {
            // arrange
            var controller = new OrderController(this.orderService, this.formsAuthentication);
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
                            RetailerName = "Amazon, Inc.", 
                            Status = "Received"
                        }, 
                    new OrderViewModel
                        {
                            Id = 2, 
                            CreatedDate = currentDate.AddDays(-40), 
                            OrderNumber = "order number test 2", 
                            ReceivedDate = currentDate.AddDays(-25), 
                            TrackingNumber = "tracking number test 2", 
                            RetailerName = "Amazon, Inc.", 
                            Status = "Received"
                        }, 
                    new OrderViewModel
                        {
                            Id = 3, 
                            CreatedDate = currentDate.AddDays(-15), 
                            OrderNumber = "order number test 3", 
                            ReceivedDate = DateTime.MinValue, 
                            TrackingNumber = "tracking number test 3", 
                            RetailerName = "Amazon, Inc.", 
                            Status = "New"
                        }
                };

            // act
            var actual = controller.GetRecent() as JsonResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                var actualOrders = (List<OrderViewModel>)actual.Data;
                for (var i = 0; i <= expected.Count; i++)
                {
                    Assert.That(actualOrders[i].Id, Is.EqualTo(expected[i].Id));
                    Assert.That(actualOrders[i].CreatedDate, Is.EqualTo(expected[i].CreatedDate).Within(1).Minutes);
                    Assert.That(actualOrders[i].ReceivedDate, Is.EqualTo(expected[i].ReceivedDate).Within(1).Minutes);
                    Assert.That(actualOrders[i].RetailerName, Is.EqualTo(expected[i].RetailerName));
                    Assert.That(actualOrders[i].OrderNumber, Is.EqualTo(expected[i].OrderNumber));
                    Assert.That(actualOrders[i].TrackingNumber, Is.EqualTo(expected[i].TrackingNumber));
                    Assert.That(actualOrders[i].Status, Is.EqualTo(expected[i].Status));
                }

            }
        }
    }
}