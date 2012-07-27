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

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Email;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.ViewModels.Account;

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
        /// The forms authentication.
        /// </summary>
        private IFormsAuthentication formsAuthentication;

        /// <summary>
        /// The email service.
        /// </summary>
        private IEmailService emailService;

        private ICookieStorageService cookieStorageService;

        /// <summary>
        /// Setup everything for orders integration tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();

            this.formsAuthentication = new FakeFormsAuthentication();
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
            this.context = new ShopAnyWareSql();
            this.userRepository = new UserRepository(this.context);
            this.roleRepository = new RoleRepository(this.context);
            this.profileRepository = new ProfileRepository(this.context);
            this.emailService = new SmtpService();
            this.cookieStorageService = new CookieStorageService();
        }

        /// <summary>
        /// Should be able to sign in.
        /// </summary>
        [Test]
        public void ShouldBeAbleToSignIn()
        {
            // arrange
            var membershipService = new MembershipService(this.userRepository, this.roleRepository, this.profileRepository);
            var controller = new AccountController(
                membershipService,
                this.emailService,
                this.cookieStorageService,
                this.formsAuthentication);

            var view = new SignInView { Email = "vhatalski@naviam.com", Password = "ruinruin", RememberMe = true };

            // act
            var actual = controller.SignIn(view) as ViewResult;
            var model = actual.Model as SignInView;

            // assert
            Assert.That(model, Is.Not.Null);
        }
    }
}