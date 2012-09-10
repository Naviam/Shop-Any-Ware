// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopperAccountCreation.cs" company="TdService">
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

    using TdService.Infrastructure.Email;
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
    public class ShopperAccountCreation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopperAccountCreation"/> class.
        /// </summary>
        public ShopperAccountCreation()
        {
            AutoMapperConfiguration.Configure();
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
            var membershipService = new MembershipService(userRepository, roleRepository, profileRepository);

            var fakeFormsAuthentication = new FakeFormsAuthentication();
            var emailService = new SmtpService();
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

                context.Users.Add(new User { Email = p0, Password = "1" });
                context.SaveChanges();
            }
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
            Debug.Assert(result != null, "result != null");
            var model = result.Data as DeliveryAddressViewModel;

            ScenarioContext.Current.Set(model, "actual");
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
            Assert.That(actual, Is.Not.Empty);
            table.CompareToInstance(actual);
        }

        /// <summary>
        /// The then i should have the following model errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following model errors")]
        public void ThenIShouldHaveTheFollowingModelErrors(Table table)
        {
            var actual = ScenarioContext.Current.Get<SignUpViewModel>("actual");
            Assert.That(actual, Is.Not.Empty);
            table.CompareToSet(actual.Errors);
        }
    }
}