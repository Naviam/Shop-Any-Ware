// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderRepositoryTests.cs" company="ServiceChannel">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Order repository for testing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    using NUnit.Framework;

    using TdService.Model.Common;
    using TdService.Model.Orders;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.ShopAnyWare.Tests.Repository;

    /// <summary>
    /// Order repository for testing.
    /// </summary>
    [TestFixture]
    public class OrderRepositoryTests
    {
        /// <summary>
        /// Shop any ware context.
        /// </summary>
        private ShopAnyWareSql context;

        /// <summary>
        /// Setup tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
            this.context = new ShopAnyWareSql();
        }

        /// <summary>
        /// Should find existing retailer by url.
        /// </summary>
        [Test]
        public void ShouldFindExistingRetailerByUrl()
        {
            // arrange
            var retailerRepository = new RetailerRepository(this.context);
            var retailer = new Retailer
            {
                Name = "Apple, Inc.",
                Url = "apple.com",
                Category = "Computers",
                Description = "Apple"
            };

            // act
            var actual = retailerRepository.FindOrAdd(retailer);
            retailerRepository.SaveChanges();

            // assert
            Assert.That(actual.Name, Is.EqualTo("Apple, Inc."));
            Assert.That(actual.Id, Is.EqualTo(1));
        }

        /// <summary>
        /// Should add retailer if url not found.
        /// </summary>
        [Test]
        public void ShouldAddRetailerIfUrlNotFound()
        {
            // arrange
            var retailerRepository = new RetailerRepository(this.context);
            var retailer = new Retailer
                {
                    Name = "Amazon, Inc.",
                    Url = "amazon.com",
                    Category = "Entertainment",
                    Description = "Amazon"
                };

            if (retailer.GetBrokenRules().Any())
            {
                var message = new StringBuilder();
                foreach (var rule in retailer.GetBrokenRules())
                {
                    message.Append(rule.Rule);
                }

                Assert.Fail(message.ToString());
            }

            // act
            var actual = retailerRepository.FindOrAdd(retailer);
            retailerRepository.SaveChanges();

            // assert
            Assert.That(actual.Id, Is.Positive);
        }

        [Test]
        public void ShouldBeAbleToDeleteOrder()
        {
            // arrange
            var repository = new OrderRepository(this.context);

        }

        /// <summary>
        /// Should add new order.
        /// </summary>
        [Test]
        public void ShouldAddNewOrder()
        {
            // arrange
            var orderRepository = new OrderRepository(this.context);
            var retailerRepository = new RetailerRepository(this.context);

            const string ShopName = "apple.com";
            var retailer = new Retailer(ShopName);
            retailer = retailerRepository.FindOrAdd(retailer);
            retailerRepository.SaveChanges();

            var newOrder = Order.CreateNew(retailer);

            if (newOrder.GetBrokenRules().Any())
            {
                var message = new StringBuilder();
                foreach (var rule in newOrder.GetBrokenRules())
                {
                    message.Append(rule.Rule);
                }

                Assert.Fail(message.ToString());
            }

            // act
            var orderResult = orderRepository.AddOrder(newOrder);
            orderRepository.SaveChanges();

            // assert
            Assert.That(orderResult.Id, Is.Positive);
        }
    }
}