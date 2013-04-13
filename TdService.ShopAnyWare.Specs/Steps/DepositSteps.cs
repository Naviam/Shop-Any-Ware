// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepositSteps.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The deposit steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using NUnit.Framework;

    using Rhino.Mocks;

    using TdService.Services.Implementations;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.MVC;
    using TdService.UI.Web.ViewModels.Ballance;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The deposit steps.
    /// </summary>
    [Binding]
    public class DepositSteps
    {
        /// <summary>
        /// The get items controller.
        /// </summary>
        /// <returns>
        /// The <see cref="ItemsController"/>.
        /// </returns>
        public BallanceController GetBalanceController()
        {
            var membershipService = ScenarioContext.Current.Get<MembershipService>();
            var fakeFormsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            var transactionService = ScenarioContext.Current.Get<TransactionService>();
            var controller = new BallanceController(membershipService, transactionService, fakeFormsAuthentication);

            var app = new MvcApplication();
            var routes = new RouteCollection();
            app.RegisterRoutes(routes);
            var request = MockRepository.GenerateStub<HttpRequestBase>();
            request.Stub(x => x.ApplicationPath).Return("/");
            request.Stub(x => x.Url).Return(new Uri("http://localhost/a", UriKind.Absolute));
            request.Stub(x => x.ServerVariables).Return(new System.Collections.Specialized.NameValueCollection());
            var response = MockRepository.GenerateStub<HttpResponseBase>();
            response.Stub(x => x.ApplyAppPathModifier(Arg<string>.Is.Anything))
            .Return("localhost")
            .WhenCalled(x => x.ReturnValue = x.Arguments[0]);
            var context = MockRepository.GenerateStub<HttpContextBase>();
            context.Stub(x => x.Request).Return(request);
            context.Stub(x => x.Response).Return(response);

            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);
            controller.Url = new UrlHelper(new RequestContext(context, new RouteData()), routes);
            return controller;
        }

        /// <summary>
        /// The given i enter the following amount INT the deposit textbox and press add funds button.
        /// </summary>
        /// <param name="amount">
        /// The amount.
        /// </param>
        [Given(@"I enter the following amount '(.*)' int the deposit textbox and press Add funds button")]
        public void GivenIEnterTheFollowingAmountIntTheDepositTextboxAndPressAddFundsButton(int amount)
        {
            var controller = this.GetBalanceController();
            var actionResult = controller.AddTransaction(amount.ToString(CultureInfo.InvariantCulture)) as JsonNetResult;
            ScenarioContext.Current.Set(actionResult);
        }

        /// <summary>
        /// The then the URL in the add transaction response should start with.
        /// </summary>
        /// <param name="url">
        /// The URL.
        /// </param>
        [Then(@"the PP URL in the AddTransaction responce should start with '(.*)'")]
        public void ThenThePPURLInTheAddTransactionResponceShouldStartWith(string url)
        {
            var actionResult = ScenarioContext.Current.Get<JsonNetResult>();
            Assert.That(actionResult, Is.Not.Null);
            var data = actionResult.Data as AddTransactionViewModel;
            Assert.That(data, Is.Not.Null);

            Debug.Assert(data != null, "data != null");
            Assert.That(data.RedirectUrl, Is.StringStarting(url));
        }

        /// <summary>
        /// The then there should be a transaction for me as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"there should be a transaction for me as follows")]
        public void ThenThereShouldBeATransactionForMeAsFollows(Table table)
        {
            var controller = this.GetBalanceController();
            var actionResult = controller.TransactionHistory() as JsonNetResult;
            Assert.That(actionResult, Is.Not.Null);
            Debug.Assert(actionResult != null, "actionResult != null");
            var data = actionResult.Data as List<TransactionsViewModel>;
            Assert.That(data, Is.Not.Null);
            Debug.Assert(data != null, "data != null");
            Assert.AreNotEqual(data.Count, 0);
            var tran = data.OrderByDescending(tr => tr.Date).First();

            Assert.AreEqual(tran.OperationAmount, decimal.Parse(table.Rows[0][0]));
            Assert.AreEqual(tran.TransactionStatus, table.Rows[0][1]);
        }
    }
}
