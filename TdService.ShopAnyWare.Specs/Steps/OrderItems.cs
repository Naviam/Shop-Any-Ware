// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItems.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Item;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The order items.
    /// </summary>
    [Binding]
    public class OrderItems
    {
        /// <summary>
        /// The get items controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ItemsController"/>.
        /// </returns>
        public ItemsController GetItemsController()
        {
            var itemService = ScenarioContext.Current.Get<ItemsService>();
            var fakeFormsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            return new ItemsController(itemService, fakeFormsAuthentication);
        }

        /// <summary>
        /// The when i add the following items to order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I add the following items to order '(.*)'")]
        public void WhenIAddTheFollowingItemsToOrder(int orderId, Table table)
        {
            var contoller = this.GetItemsController();
            var itemViewModels = table.CreateSet<OrderItemViewModel>();
            var actuals = new List<OrderItemViewModel>();
            foreach (var itemViewModel in itemViewModels)
            {
                itemViewModel.OrderId = orderId;
                var result = contoller.AddItemToOrder(itemViewModel) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result == null)
                {
                    continue;
                }

                var actual = result.Data as OrderItemViewModel;
                actuals.Add(actual);
            }

            ScenarioContext.Current.Set(actuals);
        }

        /// <summary>
        /// The when i remove the following order items.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I remove the following order items")]
        public void WhenIRemoveTheFollowingOrderItems(Table table)
        {
            var contoller = this.GetItemsController();
            var itemViewModels = table.CreateSet<OrderItemViewModel>();
            var actuals = new List<OrderItemViewModel>();
            foreach (var itemViewModel in itemViewModels)
            {
                var result = contoller.RemoveItem(itemViewModel.Id) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result == null)
                {
                    continue;
                }

                var actual = result.Data as OrderItemViewModel;
                actuals.Add(actual);
            }

            ScenarioContext.Current.Set(actuals);
        }

        /// <summary>
        /// The when i update items of order as follows.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I update items of order '(.*)' as follows")]
        public void WhenIUpdateItemsOfOrderAsFollows(int orderId, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// The then the order item view model should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the order item view model should be as follows")]
        public void ThenTheOrderItemViewModelShouldBeAsFollows(Table table)
        {
            var actual = ScenarioContext.Current.Get<List<OrderItemViewModel>>();
            Assert.That(actual, Is.Not.Null);
            table.CompareToSet(actual);
        }
    }
}