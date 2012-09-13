﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign in steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.UI.Web;
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
        /// The when i fill sign in form with the following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I fill sign in form with the following data")]
        public void WhenIFillSignInFormWithTheFollowingData(Table table)
        {
            var controller = ScenarioContext.Current.Get<AccountController>();
            var signInModel = table.CreateInstance<SignInViewModel>();
            var result = controller.SignIn(signInModel);
            ScenarioContext.Current.Set(result, "controllerResponse");
        }

        /// <summary>
        /// The then the signin result should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the signin result should be as follows")]
        public void ThenTheSigninResultShouldBeAsFollows(Table table)
        {
            var result = ScenarioContext.Current.Get<JsonNetResult>("controllerResponse");
            Assert.That(result, Is.Not.Null);
            var actual = result.Data as SignInViewModel;
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
        }

        /// <summary>
        /// The then the signin view model should have following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the signin view model should have following errors")]
        public void ThenTheSigninViewModelShouldHaveFollowingErrors(Table table)
        {
            var result = ScenarioContext.Current.Get<JsonNetResult>("controllerResponse");
            Assert.That(result, Is.Not.Null);
            var actual = result.Data as SignInViewModel;
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            Assert.That(actual.BrokenRules, Is.Not.Null);
            table.CompareToSet(actual.BrokenRules);
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