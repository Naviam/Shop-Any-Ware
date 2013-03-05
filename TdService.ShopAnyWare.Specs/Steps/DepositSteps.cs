using System;
using System.Collections.Generic;
using NUnit.Framework;
using TdService.Model.Membership;
using TdService.Services.Interfaces;
using TdService.ShopAnyWare.Specs.Fakes;
using TdService.UI.Web;
using TdService.UI.Web.Controllers;
using TdService.UI.Web.ViewModels.Ballance;
using TechTalk.SpecFlow;
using System.Linq;
using TdService.Services.Implementations;
using Rhino.Mocks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using TdService.UI.Web.MVC;

namespace TdService.ShopAnyWare.Specs.Steps
{
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

        [Given(@"I enter the following amount '(.*)' int the deposit textbox and press Add funds button")]
        public void GivenIEnterTheFollowingAmountIntTheDepositTextboxAndPressAddFundsButton(int amount)
        {
            var controller = this.GetBalanceController();
            var actionResult = controller.AddTransaction(amount.ToString()) as JsonNetResult;
            ScenarioContext.Current.Set(actionResult);
        }

        [Then(@"the PP URL in the AddTransaction responce should start with '(.*)'")]
        public void ThenThePPURLInTheAddTransactionResponceShouldStartWith(string ppUrl)
        {
            var actionResult = ScenarioContext.Current.Get<JsonNetResult>();
            Assert.That(actionResult, Is.Not.Null);
            var data = actionResult.Data as AddTransactionViewModel;
            Assert.That(data, Is.Not.Null);

            Assert.That(data.RedirectUrl, Is.StringStarting(ppUrl));
        }

        [Then(@"there should be a transaction for me as follows")]
        public void ThenThereShouldBeATransactionForMeAsFollows(Table table)
        {
            var controller = this.GetBalanceController();
            var actionResult = controller.TransactionHistory() as JsonNetResult;
            Assert.That(actionResult, Is.Not.Null);
            var data = actionResult.Data as List<TransactionsViewModel>;
            Assert.That(data, Is.Not.Null);
            Assert.AreNotEqual(data.Count, 0);
            var tran = data.OrderByDescending(tr => tr.Date).First();

            Assert.AreEqual(tran.OperationAmount, decimal.Parse(table.Rows[0][0]));
            Assert.AreEqual(tran.TransactionStatus, table.Rows[0][1]);

        }
    }
}
