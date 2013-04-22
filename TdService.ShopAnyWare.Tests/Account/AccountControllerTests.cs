// -----------------------------------------------------------------------
// <copyright file="AccountControllerTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Email;
    using TdService.Services.Interfaces;
    using TdService.ShopAnyWare.Tests.Helpers;
    using TdService.ShopAnyWare.Tests.Mocks;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// This class contains unit tests for account controller methods.
    /// </summary>
    [TestFixture]
    public class AccountControllerTests
    {
        /// <summary>
        /// Gets or sets membership service.
        /// </summary>
        private IMembershipService MembershipService { get; set; }

        /// <summary>
        /// Gets or sets Forms Authentication.
        /// </summary>
        private IFormsAuthentication FormsAuthentication { get; set; }

        /// <summary>
        /// Gets or sets Email Service.
        /// </summary>
        private IEmailService EmailService { get; set; }

        /// <summary>
        /// Gets or sets Cookie Storage Service.
        /// </summary>
        private ICookieStorageService CookieStorageService { get; set; }

        /// <summary>
        /// Initial setup for account controller tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.MembershipService = new FakeMembershipService();
            this.FormsAuthentication = new FakeFormsAuthentication();
            this.EmailService = new FakeEmailService();
            this.CookieStorageService = new FakeCookieProvider();
        }

        /// <summary>
        /// Should show login page test.
        /// </summary>
        [Test]
        public void ShouldShowSignInPage()
        {
            // arrange
            var controller = new AccountController(
                this.MembershipService,
                this.CookieStorageService,
                this.FormsAuthentication);
            const string Expected = "SignIn";

            // act
            var actual = (ViewResult)controller.SignIn();

            // asset
            Assert.That(actual.ViewName, Is.EqualTo(Expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(MainViewModel)));
        }

        /// <summary>
        /// Should show registration page.
        /// </summary>
        [Test]
        public void ShouldShowSignUpPage()
        {
            // arrange
            var controller = new AccountController(
                this.MembershipService,
                this.CookieStorageService,
                this.FormsAuthentication);
            const string Expected = "SignUp";

            // act
            var actual = (ViewResult)controller.SignUp();

            // assert
            Assert.That(actual.ViewName, Is.EqualTo(Expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(MainViewModel)));
        }

        /// <summary>
        /// Should show forgot password page.
        /// </summary>
        [Test]
        public void ShouldShowForgotPasswordPage()
        {
            // arrange
            var controller = new AccountController(
                this.MembershipService,
                this.CookieStorageService,
                this.FormsAuthentication);
            var expected = string.Empty;

            // act
            var actual = (ViewResult)controller.Forgot();

            // assert
            Assert.That(actual.ViewName, Is.EqualTo(expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(ForgotPasswordViewModel)));
        }

        /// <summary>
        /// Should be able to reset password test.
        /// </summary>
        [Test]
        public void ShouldBeAbleToResetPasswordAndSendItToValidEmail()
        {
            // arrange
            var controller = new AccountController(
                this.MembershipService,
                this.CookieStorageService,
                this.FormsAuthentication);
            var view = new ForgotPasswordViewModel { Email = "vhatalski@naviam.com" };

            // act
            var actual = (ViewResult)controller.Forgot(view);
            var model = (ForgotPasswordViewModel)actual.ViewData.Model;

            // assert
            Assert.That(model, Is.Not.Null);
        }

        /// <summary>
        /// Should be able to log off only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToLogOffOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(AccountController), "SignOut");
        }
    }
}