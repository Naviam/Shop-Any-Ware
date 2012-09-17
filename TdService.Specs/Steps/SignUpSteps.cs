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
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
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
        public AccountAuthController GetAccountController()
        {
            return new AccountAuthController(
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
            var controller = this.GetAccountController();
            var result = controller.SignUp(signUpModel) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            Debug.Assert(result != null, "result != null");
            var model = result.Data as SignUpViewModel;

            ScenarioContext.Current.Set(model, "actual");
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

            ScenarioContext.Current.Set(model, "actual");
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
            var actual = ScenarioContext.Current.Get<VerifyEmailViewModel>("actual");
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
            var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
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
            var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.BrokenRules, Is.Not.Null);
            table.CompareToSet(actual.BrokenRules);
        }

        /// <summary>
        /// The then activation code should be generated.
        /// </summary>
        [Then(@"activation code should be generated")]
        public void ThenActivationCodeShouldBeGenerated()
        {
            var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            Assert.That(actual.ActivationCode, Is.Not.Empty);
        }

        /// <summary>
        /// The then email with activation code should be sent to registration email address.
        /// </summary>
        [Then(@"email with activation code should be sent to registration email address")]
        public void ThenEmailWithActivationCodeShouldBeSentToRegistrationEmailAddress()
        {
            var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            var emailService = ScenarioContext.Current.Get<FakeEmailService>();
            Assert.That(emailService.SentMails.Any(), Is.True);
            var sentEmail = emailService.SentMails.First();
            Assert.That(sentEmail.To, Is.EqualTo(actual.Email));
            Assert.That(sentEmail.Body, Contains.Substring(actual.ActivationCode));
        }
    }
}