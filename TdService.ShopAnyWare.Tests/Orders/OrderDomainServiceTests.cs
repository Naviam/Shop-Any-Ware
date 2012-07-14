namespace TdService.ShopAnyWare.Tests.DomainServices
{
    using System.Data.Entity;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Model.DomainServices;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.ShopAnyWare.Tests.Repository;

    /// <summary>
    /// Order service tests.
    /// </summary>
    [TestFixture]
    public class OrderDomainServiceTests
    {
        /// <summary>
        /// Shop any ware context.
        /// </summary>
        private ShopAnyWareSql context;

        [SetUp]
        public void SetUp()
        {
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
            this.context = new ShopAnyWareSql();
        }

        [Test]
        public void ShouldBeAbleToCreateNewOrder()
        {
            // arrange
            const string ParameterEmail = "vhatalski@naviam.com";
            const string ParameterShopNameOrUrl = "apple.com";
            var userRepository = new UserRepository(this.context);
            var orderRepository = new OrderRepository(this.context);
            var retailerRepository = new RetailerRepository(this.context);
            var orderService = new OrderDomainService(userRepository, orderRepository, retailerRepository);

            // act
            var order = orderService.AddNewOrderToUser(ParameterEmail, ParameterShopNameOrUrl);

            // assert
            var user = userRepository.GetUserByEmail(ParameterEmail);
            Assert.That(user.GetRecentOrders().SingleOrDefault(o => o.Id == order.Id), Is.EqualTo(order));
        }
    }
}