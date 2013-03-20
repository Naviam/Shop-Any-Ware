// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageItemsSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package items steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using NUnit.Framework;
    using TdService.Model.Items;
    using TdService.Repository.MsSql;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using System.Linq;
    using TdService.Services.Implementations;

    /// <summary>
    /// The package items steps.
    /// </summary>
    [Binding]
    public class PackageItemsSteps
    {
        private ItemsController GetItemsController()
        {
            var itemsService = ScenarioContext.Current.Get<ItemsService>();
            var fakeFormsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            var controller = new ItemsController(itemsService, fakeFormsAuthentication);
            return controller;
        }

        /// <summary>
        /// The when i add item to package with the following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I add item to package with the following data")]
        public void WhenIAddItemToPackageWithTheFollowingData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// The then i should have the following package items.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following package items")]
        public void ThenIShouldHaveTheFollowingPackageItems(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I move all items in order '(.*)' to package '(.*)'")]
        public void WhenIMoveAllItemsInOrderToPackage(string orderNumber, string packageName)
        {
            var user = ScenarioContext.Current.Get<TdService.Model.Membership.User>();
            var order = user.Orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            var package = user.Packages.SingleOrDefault(p => p.Name == packageName);
            var controller = GetItemsController();
            var actual = controller.MoveOrderItemsToExistingPackage(order.Id, package.Id) as JsonNetResult;
            Assert.IsNotNull(actual);
            Assert.That(actual.Data is ViewModelBase);
            Assert.That((actual.Data as ViewModelBase).MessageType.Equals(MessageType.Success.ToString()));
            ScenarioContext.Current.Set<int>(package.Id, "PackageId");
        }

        [Then(@"there should be following items for this package")]
        public void ThenThereShouldBeFollowingItemsForPackage(Table table)
        {
            var packageId = ScenarioContext.Current.Get<int>("PackageId");
            var items = table.CreateSet<Item>().ToList();
            var itemsService = ScenarioContext.Current.Get<ItemsService>();
            var actual =
                itemsService.GetPackageItems(
                    new Services.Messaging.Item.GetPackageItemsRequest { PackageId = packageId });
            Assert.That(actual.Items.Count.Equals(items.Count));
            foreach (var resp in actual.Items)
            {
                var item = items.SingleOrDefault(i => i.Name.Equals(resp.Name) && i.Price.Equals(resp.Price) && i.Quantity.Equals(resp.Quantity));
                Assert.IsNotNull(item);
            }
        }

        [When(@"I move all items in order '(.*)' to new package '(.*)'")]
        public void WhenIMoveAllItemsInOrderToNewPackage(string orderNumber, string packageName)
        {
            var user = ScenarioContext.Current.Get<TdService.Model.Membership.User>();
            var order = user.Orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            var controller = GetItemsController();
            var actual = controller.MoveOrderItemsToNewPackage(order.Id, packageName) as JsonNetResult;
            Assert.IsNotNull(actual);
            Assert.That(actual.Data is ViewModelBase);
            Assert.That((actual.Data as ViewModelBase).MessageType.Equals(MessageType.Success.ToString()));
        }

        [When(@"I move all items from package '(.*)' back to their original order")]
        public void WhenIMoveAllItemsFromPackageBackToTheirOriginalOrder(string packageName)
        {
            var user = ScenarioContext.Current.Get<TdService.Model.Membership.User>();
            var package = user.Packages.SingleOrDefault(p => p.Name == packageName);
            var controller = GetItemsController();
            var actual = controller.MoveOrderItemsToOriginalOrder(package.Id) as JsonNetResult;
            Assert.IsNotNull(actual);
            Assert.That(actual.Data is ViewModelBase);
            Assert.That((actual.Data as ViewModelBase).MessageType.Equals(MessageType.Success.ToString()));
        }

        [Then(@"there should be following items for order '(.*)'")]
        public void ThenThereShouldBeFollowingItemsForOrder(string orderNumber, Table table)
        {
            var user = ScenarioContext.Current.Get<TdService.Model.Membership.User>();
            var order = user.Orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            var items = table.CreateSet<Item>().ToList();
            var itemsService = ScenarioContext.Current.Get<ItemsService>();
            var actual =
                itemsService.GetOrderItems(
                    new Services.Messaging.Item.GetOrderItemsRequest { OrderId = order.Id });
            Assert.That(actual.Count.Equals(items.Count));
            foreach (var resp in actual)
            {
                var item = items.SingleOrDefault(i => i.Id.Equals(resp.Id));
                Assert.IsNotNull(item);
                Assert.AreEqual(item.Name, resp.Name);
            }
        }

    }
}
