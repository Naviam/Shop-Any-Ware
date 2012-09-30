// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignUpSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shopper account creation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Repository.MsSql;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.Specs.Infrastructure;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The shopper account creation.
    /// </summary>
    [Binding]
    public class SignUpSteps
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
        /// The when i fill sign up form with the following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I fill sign up form with the following data")]
        public void WhenIFillSignUpFormWithTheFollowingData(Table table)
        {
            var signUpModel = table.CreateInstance<SignUpViewModel>();
            ScenarioContext.Current.Set(signUpModel);
            var controller = this.GetAccountController();
            var result = controller.SignUp(signUpModel);
            Assert.That(result, Is.Not.Null);
            ScenarioContext.Current.Set(result, "controllerResponse");
        }

        /// <summary>
        /// The when i enter email to verify existence.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        [When(@"I enter email '(.*)' to verify existence")]
        public void WhenIEnterEmailToVerifyExistence(string email)
        {
            var controller = this.GetAccountController();
            var result = controller.VerifyEmail(email) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            Debug.Assert(result != null, "result != null");
            var model = result.Data as VerifyEmailViewModel;

            ScenarioContext.Current.Set(model);
        }

        /// <summary>
        /// The then the verify email view model should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the verify email view model should be as follows")]
        public void ThenTheVerifyEmailViewModelShouldBeAsFollows(Table table)
        {
            var actual = ScenarioContext.Current.Get<VerifyEmailViewModel>();
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
        }

        /// <summary>
        /// The then i should have the result as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the result as follows")]
        public void ThenIShouldHaveTheResultAsFollows(Table table)
        {
            var actual = ScenarioContext.Current.Get<ViewResult>("controllerResponse");
            Assert.That(actual, Is.Not.Null);
            var mainModel = actual.Model as MainViewModel;
            Assert.That(mainModel, Is.Not.Null);
            Debug.Assert(mainModel != null, "mainModel != null");
            Assert.That(mainModel.SignUpViewModel, Is.Not.Null);
            table.CompareToInstance(mainModel.SignUpViewModel);
        }

        /// <summary>
        /// The then the signup view model should have following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the signup view model should have following errors")]
        public void ThenTheSignupViewModelShouldHaveFollowingErrors(Table table)
        {
            var actual = ScenarioContext.Current.Get<ViewResult>("controllerResponse");
            Assert.That(actual, Is.Not.Null);
            var mainModel = actual.Model as MainViewModel;
            Assert.That(mainModel, Is.Not.Null);
            Debug.Assert(mainModel != null, "mainModel != null");
            Assert.That(mainModel.SignUpViewModel, Is.Not.Null);
            Assert.That(mainModel.SignUpViewModel.BrokenRules, Is.Not.Null);
            table.ReplaceErrorCodeWithMessage().CompareToSet(mainModel.SignUpViewModel.BrokenRules);
        }

        /// <summary>
        /// The then activation code should be generated.
        /// </summary>
        [Then(@"activation code should be generated")]
        public void ThenActivationCodeShouldBeGenerated()
        {
            var signUpModel = ScenarioContext.Current.Get<SignUpViewModel>();
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == signUpModel.Email);
                Debug.Assert(user != null, "user != null");
                Assert.That(user.ActivationCode, Is.Not.Null);
                ScenarioContext.Current.Set(user.ActivationCode, "activationCode");
            }
        }

        /// <summary>
        /// The then email with activation code should be sent to registration email address.
        /// </summary>
        [Then(@"email with activation code should be sent to registration email address")]
        public void ThenEmailWithActivationCodeShouldBeSentToRegistrationEmailAddress()
        {
            ////var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            var emailService = ScenarioContext.Current.Get<FakeEmailService>();
            Assert.That(emailService.SentMails.Any(), Is.True);
            var sentEmail = emailService.SentMails.First();
            var signUpModel = ScenarioContext.Current.Get<SignUpViewModel>();

            Assert.That(sentEmail.To, Is.EqualTo(signUpModel.Email));
            var code = ScenarioContext.Current.Get<Guid>("activationCode");
            Assert.That(sentEmail.Body, Contains.Substring(code.ToString()));
        }
    }
}