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
            return new ItemsController(ScenarioContext.Current.Get<ItemsService>(), ScenarioContext.Current.Get<FakeFormsAuthentication>());
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
                var result = contoller.AddItemToOrder(itemViewModel) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result != null)
                {
                    var actual = result.Data as OrderItemViewModel;
                    actuals.Add(actual);
                }
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
            ScenarioContext.Current.Pending();
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
            ScenarioContext.Current.Pending();
        }
    }
}