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
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Repository.MsSql;
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
        /// The when i remove the following orders.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I remove the following orders")]
        public void WhenIRemoveTheFollowingOrders(Table table)
        {
            var orderIdsToRemove = table.CreateSet<OrderViewModel>();
            var contoller = this.GetOrdersController();

            var models = new List<OrderViewModel>();
            foreach (var id in orderIdsToRemove)
            {
                var result = contoller.Remove(id.Id) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result != null)
                {
                    var actual = result.Data as OrderViewModel;
                    models.Add(actual);
                }
            }

            ScenarioContext.Current.Set(models);
        }

        /// <summary>
        /// The when i update order as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I update order as follows")]
        public void WhenIUpdateOrderAsFollows(Table table)
        {
            var model = table.CreateInstance<OrderViewModel>();
            var contoller = this.GetOrdersController();
            var result = contoller.Update(model) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as OrderViewModel;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i update orders as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I update orders as follows")]
        public void WhenIUpdateOrdersAsFollows(Table table)
        {
            var models = table.CreateSet<OrderViewModel>();
            var contoller = this.GetOrdersController();
            var actuals = new List<OrderViewModel>();
            foreach (var model in models)
            {
                var result = contoller.Update(model) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result != null)
                {
                    actuals.Add(result.Data as OrderViewModel);
                }
            }

            ScenarioContext.Current.Set(actuals);
        }

        /// <summary>
        /// The when i request for following orders return.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I request for following orders return")]
        public void WhenIRequestForFollowingOrdersReturn(Table table)
        {
            var models = table.CreateSet<OrderViewModel>();
            var contoller = this.GetOrdersController();
            var actuals = new List<OrderViewModel>();
            foreach (var model in models)
            {
                var result = contoller.RequestForReturn(model) as JsonNetResult;
                Assert.That(result, Is.Not.Null);
                if (result != null)
                {
                    actuals.Add(result.Data as OrderViewModel);
                }
            }

            ScenarioContext.Current.Set(actuals);
        }

        /// <summary>
        /// The when i go to my recent orders tab.
        /// </summary>
        [When(@"I go to my recent orders tab")]
        public void WhenIGoToMyRecentOrdersTab()
        {
            var contoller = this.GetOrdersController();
            var result = contoller.Recent() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<OrderViewModel>;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i go to my history orders tab.
        /// </summary>
        [When(@"I go to my history orders tab")]
        public void WhenIGoToMyHistoryOrdersTab()
        {
            var contoller = this.GetOrdersController();
            var result = contoller.History() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<OrderViewModel>;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i go to new orders tab on operator dashboard page.
        /// </summary>
        [When(@"I go to new orders tab on operator dashboard page")]
        public void WhenIGoToNewOrdersTabOnOperatorDashboardPage()
        {
            var contoller = this.GetOrdersController();
            var result = contoller.NewOrders() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<OrderViewModel>;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i go to received orders tab on operator dashboard page.
        /// </summary>
        [When(@"I go to received orders tab on operator dashboard page")]
        public void WhenIGoToReceivedOrdersTabOnOperatorDashboardPage()
        {
            var contoller = this.GetOrdersController();
            var result = contoller.ReceivedOrders() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<OrderViewModel>;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The when i go to return requested orders tab on operator dashboard page.
        /// </summary>
        [When(@"I go to return requested orders tab on operator dashboard page")]
        public void WhenIGoToReturnRequestedOrdersTabOnOperatorDashboardPage()
        {
            var contoller = this.GetOrdersController();
            var result = contoller.ReturnRequestedOrders() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<OrderViewModel>;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The then there must be only one db record with retailer url.
        /// </summary>
        /// <param name="retailerUrl">
        /// The retailer url.
        /// </param>
        [Then(@"there must be only one db record with '(.*)' retailer url")]
        public void ThenThereMustBeOnlyOneDbRecordWithRetailerUrl(string retailerUrl)
        {
            using (var context = new ShopAnyWareSql())
            {
                var retailers = context.Retailers.Where(r => r.Url == retailerUrl);
                Assert.That(retailers.Count(), Is.EqualTo(1));
            }
        }

        /// <summary>
        /// The then the order view models should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the order view models should be as follows")]
        public void ThenTheOrderViewModelsShouldBeAsFollows(Table table)
        {
            var actual = ScenarioContext.Current.Get<List<OrderViewModel>>();
            Assert.That(actual, Is.Not.Empty);
            table.CompareToSet(actual);
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
