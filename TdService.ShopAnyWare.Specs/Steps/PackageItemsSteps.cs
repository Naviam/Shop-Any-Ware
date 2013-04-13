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
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Model.Items;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The package items steps.
    /// </summary>
    [Binding]
    public class PackageItemsSteps
    {
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

        /// <summary>
        /// The when i move all items in order to package.
        /// </summary>
        /// <param name="orderNumber">
        /// The order number.
        /// </param>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        [When(@"I move all items in order '(.*)' to package '(.*)'")]
        public void WhenIMoveAllItemsInOrderToPackage(string orderNumber, string packageName)
        {
            var user = ScenarioContext.Current.Get<Model.Membership.User>();
            var order = user.Orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            var package = user.Packages.SingleOrDefault(p => p.Name == packageName);
            var controller = this.GetItemsController();
            Debug.Assert(order != null, "order != null");
            Debug.Assert(package != null, "package != null");
            var actual = controller.MoveOrderItemsToExistingPackage(order.Id, package.Id) as JsonNetResult;
            Assert.IsNotNull(actual);
            Assert.That(actual.Data is ViewModelBase);
            Assert.That((actual.Data as ViewModelBase).MessageType.Equals(MessageType.Success.ToString()));
            ScenarioContext.Current.Set(package.Id, "PackageId");
        }

        /// <summary>
        /// The then there should be following items for package.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
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

        /// <summary>
        /// The when i move all items from package back to their original order.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        [When(@"I move all items from package '(.*)' back to their original order")]
        public void WhenIMoveAllItemsFromPackageBackToTheirOriginalOrder(string packageName)
        {
            var user = ScenarioContext.Current.Get<Model.Membership.User>();
            var package = user.Packages.SingleOrDefault(p => p.Name == packageName);
            var controller = this.GetItemsController();
            Debug.Assert(package != null, "package != null");
            var actual = controller.MoveOrderItemsToOriginalOrder(package.Id) as JsonNetResult;
            Assert.IsNotNull(actual);
            Assert.That(actual.Data is ViewModelBase);
            Assert.That((actual.Data as ViewModelBase).MessageType.Equals(MessageType.Success.ToString()));
        }

        /// <summary>
        /// The then there should be following items for order.
        /// </summary>
        /// <param name="orderNumber">
        /// The order number.
        /// </param>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"there should be following items for order '(.*)'")]
        public void ThenThereShouldBeFollowingItemsForOrder(string orderNumber, Table table)
        {
            var user = ScenarioContext.Current.Get<Model.Membership.User>();
            var order = user.Orders.SingleOrDefault(o => o.OrderNumber == orderNumber);
            var items = table.CreateSet<Item>().ToList();
            var itemsService = ScenarioContext.Current.Get<ItemsService>();
            Debug.Assert(order != null, "order != null");
            var actual = itemsService.GetOrderItems(new Services.Messaging.Item.GetOrderItemsRequest { OrderId = order.Id });
            Assert.That(actual.Count.Equals(items.Count));
            foreach (var resp in actual)
            {
                var item = items.SingleOrDefault(i => i.Name.Equals(resp.Name) && i.Price.Equals(resp.Price) && i.Quantity.Equals(resp.Quantity));
                Assert.IsNotNull(item);
                Assert.AreEqual(item.Name, resp.Name);
            }
        }

        /// <summary>
        /// The get items controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ItemsController"/>.
        /// </returns>
        private ItemsController GetItemsController()
        {
            var itemsService = ScenarioContext.Current.Get<ItemsService>();
            var fakeFormsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            var controller = new ItemsController(itemsService, fakeFormsAuthentication);
            return controller;
        }
    }
}
