// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountIntegrationTests.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AccountIntegrationTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Email;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The account integration tests.
    /// </summary>
    [TestFixture]
    public class AccountIntegrationTests
    {
        /// <summary>
        /// Shop any ware context.
        /// </summary>
        private ShopAnyWareSql context;

        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// The role repository.
        /// </summary>
        private IRoleRepository roleRepository;

        /// <summary>
        /// The profile repository.
        /// </summary>
        private IProfileRepository profileRepository;

        /// <summary>
        /// The membership repository.
        /// </summary>
        private IMembershipRepository membershipRepository;

        /// <summary>
        /// The forms authentication.
        /// </summary>
        private IFormsAuthentication formsAuthentication;

        /// <summary>
        /// The email service.
        /// </summary>
        private IEmailService emailService;

        /// <summary>
        /// The cookie storage service.
        /// </summary>
        private ICookieStorageService cookieStorageService;

        /// <summary>
        /// Setup everything for orders integration tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            Database.SetInitializer(new ShopAnyWareTestInitilizer());

            this.formsAuthentication = new FakeFormsAuthentication();
            this.context = new ShopAnyWareSql();
            this.userRepository = new UserRepository(this.context);
            this.roleRepository = new RoleRepository(this.context);
            this.profileRepository = new ProfileRepository(this.context);
            this.membershipRepository = new MembershipRepository();
            this.emailService = new SmtpService();
            this.cookieStorageService = new FakeCookieProvider();
        }

        /// <summary>
        /// Should be able to sign in.
        /// </summary>
        [Test]
        public void ShouldBeAbleToSignIn()
        {
            // arrange
            var membershipService = new MembershipService(this.userRepository, this.roleRepository, this.profileRepository, this.membershipRepository);
            var controller = new AccountController(
                membershipService,
                this.emailService,
                this.cookieStorageService,
                this.formsAuthentication);

            var view = new SignInViewModel { Email = "vhatalski@naviam.com", Password = "ruinruin", RememberMe = true };

            // act
            var actual = controller.SignIn(view) as RedirectToRouteResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                Assert.That(actual.RouteValues["action"], Is.EqualTo("Dashboard"));
                Assert.That(actual.RouteValues["controller"], Is.EqualTo("Member"));
            }
        }

        /// <summary>
        /// Should be able to sign up.
        /// </summary>
        [Test]
        public void ShouldBeAbleToSignUp()
        {
            // arrange
            var membershipService = new MembershipService(this.userRepository, this.roleRepository, this.profileRepository, this.membershipRepository);
            var controller = new AccountController(
                membershipService,
                this.emailService,
                this.cookieStorageService,
                this.formsAuthentication);

            var view = new SignUpViewModel
                {
                    Email = "vhatalski_unique@naviam.com",
                    FirstName = "Vitali",
                    LastName = "Hatalski",
                    Password = "ruinruin",
                    PasswordConfirm = "ruinruin"
                };

            // act
            var actual = controller.SignUp(view) as RedirectToRouteResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                Assert.That(actual.RouteValues["action"], Is.EqualTo("Dashboard"));
                Assert.That(actual.RouteValues["controller"], Is.EqualTo("Member"));
            }
        }
    }
}