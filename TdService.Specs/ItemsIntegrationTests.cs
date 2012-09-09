// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsIntegrationTests.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The items integration tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Infrastructure.Authentication;
    using TdService.Model.Items;
    using TdService.Model.Packages;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.Interfaces;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Item;

    /// <summary>
    /// The items integration tests.
    /// </summary>
    [TestFixture]
    public class ItemsIntegrationTests
    {
        /// <summary>
        /// Shop any ware context.
        /// </summary>
        private ShopAnyWareSql context;

        /// <summary>
        /// The items service.
        /// </summary>
        private IItemsService itemsService;

        /// <summary>
        /// The items repository.
        /// </summary>
        private IItemsRepository itemsRepository;

        /// <summary>
        /// The packages repository.
        /// </summary>
        private IPackageRepository packageRepository;

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
            this.itemsRepository = new ItemsRepository(this.context);
            this.packageRepository = new PackageRepository(this.context);
            this.itemsService = new ItemsService(this.itemsRepository, this.packageRepository);
        }

        /// <summary>
        /// Should be able to view order's items.
        /// </summary>
        [Test]
        public void ShouldBeAbleToViewOrderItems()
        {
            // arrange
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
            var controller = new ItemsController(this.itemsService, this.formsAuthentication);
            const int OrderId = 1;

            // act
            var actual = controller.GetOrderItems(OrderId) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as List<OrderItemViewModel>;
            Assert.That(model, Is.Not.Null);
            Debug.Assert(model != null, "model != null");
            Assert.That(model.Any(), Is.True);
        }

        /// <summary>
        /// Should be able to add item to order.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAddItemToOrder()
        {
            // arrange
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
            var controller = new ItemsController(this.itemsService, this.formsAuthentication);
            var viewModel = new OrderItemViewModel { OrderId = 1, Name = "Kindle", Quantity = 1, Price = 70.43m, Weight = 70 };

            // act
            var actual = controller.AddItemToOrder(viewModel) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as OrderItemViewModel;
            Assert.That(model, Is.Not.Null);
            Debug.Assert(model != null, "model != null");
            Assert.That(model.Id, Is.GreaterThan(0));
        }
    }
}