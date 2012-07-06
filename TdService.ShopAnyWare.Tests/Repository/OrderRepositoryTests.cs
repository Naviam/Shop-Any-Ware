// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderRepositoryTests.cs" company="ServiceChannel">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Order repository for testing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Repository
{
    using System.Data.Entity;

    using NUnit.Framework;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Repository.MsSql.Repositories;

    /// <summary>
    /// Order repository for testing.
    /// </summary>
    [TestFixture]
    public class OrderRepositoryTests
    {
        /// <summary>
        /// Setup tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
        }

        /// <summary>
        /// Should add new order.
        /// </summary>
        [Test]
        public void ShouldAddNewOrder()
        {
            // arrange
            var orderRepository = new OrderRepository();
            var repository = new MembershipRepository();

            var user = new User(repository)
            {
                Email = "v.hatalski@gmail.com",
                Password = "ruinruin",
                Profile = new Profile
                {
                    FirstName = "Vitali",
                    LastName = "Hatalski",
                    NotifyOnOrderStatusChanged = true,
                    NotifyOnPackageStatusChanged = true
                }
            };

            var retailer = new Retailer
                {
                    Id = 0,
                    Name = "Apple, Inc.",
                    Category = "Computers",
                    Description = string.Empty,
                    Url = "apple.com"
                };

            var order = new Order(new OrderCreatedState(), retailer);

            user.Orders.Add(order);

            // act
            orderRepository.AddOrder(order);

            // assert
            orderRepository.GetOrderDetails(order.Id);
            Assert.That(user.Orders.Exists(order1 => order1 == order), Is.True);
        }
    }
}