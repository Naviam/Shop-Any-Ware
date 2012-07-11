namespace TdService.ShopAnyWare.Tests.DomainServices
{
    using NUnit.Framework;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Repository.MsSql.Repositories;

    /// <summary>
    /// Order service tests.
    /// </summary>
    [TestFixture]
    public class OrderServiceTests
    {
        private IUserRepository userRepository;

        [SetUp]
        public void SetUp()
        {
            this.userRepository = new UserRepository();
        }

        [Test]
        public void ShouldBeAbleToAddOrderToUser()
        {
            // arrange
            var user = this.userRepository.GetUserByEmail("vhatalski@naviam.com");
            var order = new Order(new OrderCreatedState(), new Retailer("apple.com"));
        }
    }
}