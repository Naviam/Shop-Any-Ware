// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign in steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using System.Diagnostics;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.ShopAnyWare.Specs.Infrastructure;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The sign in steps.
    /// </summary>
    [Binding]
    public class SignInSteps
    {
        /// <summary>
        /// The get account controller.
        /// </summary>
        /// <returns>
        /// The TdService.UI.Web.Controllers.AccountController.
        /// </returns>
        public AccountController GetAccountController()
        {
            return new AccountController(
                ScenarioContext.Current.Get<MembershipService>(),
                ScenarioContext.Current.Get<FakeEmailService>(),
                new FakeCookieProvider(),
                ScenarioContext.Current.Get<FakeFormsAuthentication>());
        }

        /// <summary>
        /// The when i fill sign in form with the following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I fill sign in form with the following data")]
        public void WhenIFillSignInFormWithTheFollowingData(Table table)
        {
            var controller = this.GetAccountController();
            var signInModel = table.CreateInstance<SignInViewModel>();
            var result = controller.SignIn(signInModel);
            ScenarioContext.Current.Set(result, "controllerResponse");
        }

        /// <summary>
        /// The then the sign in result should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the signin result should be as follows")]
        public void ThenTheSigninResultShouldBeAsFollows(Table table)
        {
            var result = ScenarioContext.Current.Get<ViewResult>("controllerResponse");
            Assert.That(result, Is.Not.Null);
            var mainViewModel = result.Model as MainViewModel;
            Assert.That(mainViewModel, Is.Not.Null);
            if (mainViewModel != null)
            {
                var actual = mainViewModel.SignInViewModel;
                Assert.That(actual, Is.Not.Null);
                table.CompareToInstance(actual);
            }
        }

        /// <summary>
        /// The then the sign in view model should have following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the signin view model should have following errors")]
        public void ThenTheSigninViewModelShouldHaveFollowingErrors(Table table)
        {
            var result = ScenarioContext.Current.Get<ViewResult>("controllerResponse");
            Assert.That(result, Is.Not.Null);
            var mainViewModel = result.Model as MainViewModel;
            Assert.That(mainViewModel, Is.Not.Null);
            if (mainViewModel != null)
            {
                var actual = mainViewModel.SignInViewModel;
                Assert.That(actual, Is.Not.Null);
                Debug.Assert(actual != null, "actual != null");
                Assert.That(actual.BrokenRules, Is.Not.Null);
                table.ReplaceErrorCodeWithMessage().CompareToSet(actual.BrokenRules);
            }
        }

        /// <summary>
        /// The then i should be redirected to controller and action.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        [Then(@"I should be redirected to controller '(.*)' and action '(.*)'")]
        public void ThenIShouldBeRedirectedToControllerAndAction(string controller, string action)
        {
            var result = ScenarioContext.Current.Get<RedirectToRouteResult>("controllerResponse");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo(action));
            Assert.That(result.RouteValues["controller"], Is.EqualTo(controller));
        }
    }
}