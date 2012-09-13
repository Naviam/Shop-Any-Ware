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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Model.Balance;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
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
        /// Initializes a new instance of the <see cref="SignUpSteps"/> class.
        /// </summary>
        public SignUpSteps()
        {
            AutoMapperConfiguration.Configure();
            ////Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        /// The before scenario code execution.
        /// </summary>
        public void BeforeScenario()
        {
            this.ReinitDatabase();
            var context = new ShopAnyWareSql();
            var userRepository = new UserRepository(context);
            var roleRepository = new RoleRepository(context);
            var profileRepository = new ProfileRepository(context);
            var membershipRepository = new MembershipRepository();
            var emailService = new FakeEmailService();
            ScenarioContext.Current.Set(emailService);
            var logger = new FakeLogger();
            var membershipService = new MembershipService(logger, emailService, userRepository, roleRepository, profileRepository, membershipRepository);

            var fakeFormsAuthentication = new FakeFormsAuthentication();
            var cookieStorage = new FakeCookieProvider();

            var accountController = new AccountController(
                membershipService,
                emailService,
                cookieStorage,
                fakeFormsAuthentication);

            ScenarioContext.Current.Set(accountController);
        }

        /// <summary>
        /// The reset database.
        /// </summary>
        [BeforeScenario("signup")]
        public void ReinitDatabase()
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Database.Delete();
                context.Database.Initialize(true);
                context.Database.CreateIfNotExists();
            }
        }

        /// <summary>
        /// The given the account already exists.
        /// </summary>
        /// <param name="p0">
        /// The p 0.
        /// </param>
        [Given(@"The '(.*)' account already exists")]
        public void GivenTheAccountAlreadyExists(string p0)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == p0);
                if (user != null)
                {
                    return;
                }

                var profile = new Profile { FirstName = "Vitali", LastName = "Hatalski" };

                context.Profiles.Add(profile);
                context.SaveChanges();

                var role = context.Roles.SingleOrDefault(r => r.Name == "Shopper")
                           ?? context.Roles.Add(new Role { Name = "Shopper" });

                user = new User
                    {
                        Email = p0,
                        Password = "ruinruin",
                        Profile = profile,
                        Wallet = new Wallet { Amount = 0m },
                        Roles = new List<Role> { role }
                    };

                context.Users.Add(user);
                context.SaveChanges();
            }

            ScenarioContext.Current.Set(p0, "email");
        }

        /// <summary>
        /// The given i have not been authenticated yet.
        /// </summary>
        [Given(@"I have not been authenticated yet")]
        public void GivenIHaveNotBeenAuthenticatedYet()
        {
            this.BeforeScenario();
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
            var controller = ScenarioContext.Current.Get<AccountController>();
            var signUpModel = table.CreateInstance<SignUpViewModel>();
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
            var controller = ScenarioContext.Current.Get<AccountController>();
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