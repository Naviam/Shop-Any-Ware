namespace TdService.ShopAnyWare.Tests.Orders
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.ShopAnyWare.Tests.Account;

    [TestFixture]
    public class OrderControllerTests
    {
        private IOrderService orderService;

        private IFormsAuthentication formsAuthentication;

        [SetUp]
        public void SetUp()
        {
            this.orderService = new FakeOrderService();
            this.formsAuthentication = new FakeFormsAuthentication();
        }

        [Test]
        public void ShouldReturnJsonCollectionOfRecentOrders()
        {
            // arrange
            var controller = new OrderController(this.orderService, this.formsAuthentication);
            var expected = new JsonResult();

            // act
            var actual = controller.GetRecent() as JsonResult;

            // assert
            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
