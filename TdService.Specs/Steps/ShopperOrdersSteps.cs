// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopperOrdersSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shopper orders steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System;

    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Order;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The shopper orders steps.
    /// </summary>
    [Binding]
    public class ShopperOrdersSteps
    {
        /// <summary>
        /// The get orders controller.
        /// </summary>
        /// <returns>
        /// The TdService.UI.Web.Controllers.OrdersController.
        /// </returns>
        public OrdersController GetOrdersController()
        {
            var formsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            var orderService = ScenarioContext.Current.Get<OrderService>();
            return new OrdersController(orderService, formsAuthentication);
        }

        /// <summary>
        /// The when i set retailer url as and press add order button on shopper dashboard page.
        /// </summary>
        /// <param name="retailerUrl">
        /// The retailer url.
        /// </param>
        [When(@"I set retailer url as '(.*)' and press add order button on shopper dashboard page")]
        public void WhenISetRetailerUrlAsAndPressAddOrderButtonOnShopperDashboardPage(string retailerUrl)
        {
            var contoller = this.GetOrdersController();
            var result = contoller.Add(retailerUrl) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as OrderViewModel;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i remove order with id.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        [When(@"I remove order with id '(.*)'")]
        public void WhenIRemoveOrderWithId(int orderId)
        {
            var contoller = this.GetOrdersController();
            var result = contoller.Remove(orderId) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as OrderViewModel;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The then the order view model should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the order view model should be as follows")]
        public void ThenTheOrderViewModelShouldBeAsFollows(Table table)
        {
            var actual = ScenarioContext.Current.Get<OrderViewModel>();
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
        }

        /// <summary>
        /// The then the order view model should have created date that is earlier than utc now.
        /// </summary>
        [Then(@"the order view model should have Created Date that is earlier than UTC Now")]
        public void ThenTheOrderViewModelShouldHaveCreatedDateThatIsEarlierThanUtcNow()
        {
            var actual = ScenarioContext.Current.Get<OrderViewModel>();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.CreatedDate, Is.LessThanOrEqualTo(DateTime.UtcNow));
        }

        /// <summary>
        /// The then the order view model should have the following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the order view model should have the following errors")]
        public void ThenTheOrderViewModelShouldHaveTheFollowingErrors(Table table)
        {
            var actual = ScenarioContext.Current.Get<OrderViewModel>();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.BrokenRules, Is.Not.Null);
            table.CompareToSet(actual.BrokenRules);
        }
    }
}
