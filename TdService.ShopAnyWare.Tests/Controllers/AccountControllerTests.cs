// -----------------------------------------------------------------------
// <copyright file="AccountControllerTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Email;
    using TdService.Services.Interfaces;
    using TdService.Services.ViewModels.Account;

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
        /// Initial setup for account controller tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.MembershipService = new FakeMembershipService();
            this.FormsAuthentication = new FakeFormsAuthentication();
            this.EmailService = new FakeEmailService();
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
                this.EmailService,
                this.FormsAuthentication);
            var expected = string.Empty;

            // act
            var actual = (ViewResult)controller.SignIn();

            // asset
            Assert.That(actual.ViewName, Is.EqualTo(expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(SignInView)));
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
                this.EmailService,
                this.FormsAuthentication);
            var expected = string.Empty;

            // act
            var actual = (ViewResult)controller.SignUp();

            // assert
            Assert.That(actual.ViewName, Is.EqualTo(expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(SignUpView)));
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
                this.EmailService,
                this.FormsAuthentication);
            var expected = string.Empty;

            // act
            var actual = (ViewResult)controller.Forgot();

            // assert
            Assert.That(actual.ViewName, Is.EqualTo(expected));
            Assert.That(actual.Model, Is.TypeOf(typeof(ForgotPasswordView)));
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
                this.EmailService,
                this.FormsAuthentication);
            var view = new ForgotPasswordView { Email = "vhatalski@naviam.com" };

            // act
            var actual = (ViewResult)controller.Forgot(view);
            var model = (ForgotPasswordView)actual.ViewData.Model;

            // assert
            Assert.That(model.MessageType, Is.EqualTo("success"));
        }

        /// <summary>
        /// Should not be able to reset password and send it to invalid email.
        /// </summary>
        [Test]
        public void ShouldNotBeAbleToResetPasswordAndSendItToInvalidEmail()
        {
            // arrange
            var controller = new AccountController(
                this.MembershipService,
                this.EmailService,
                this.FormsAuthentication);
            var view = new ForgotPasswordView { Email = "vhatalski@invalid" };

            // act
            var actual = (ViewResult)controller.Forgot(view);
            var model = (ForgotPasswordView)actual.ViewData.Model;

            // assert
            Assert.That(model.MessageType, Is.EqualTo("error"));
        }

        /// <summary>
        /// Should be able to log off only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToLogOffOnlyIfAuthorized()
        {
            AssertIsAuthorized(typeof(AccountController), "SignOut");
        }

        /// <summary>
        /// Assert is authorized helper.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        private static void AssertIsAuthorized(ICustomAttributeProvider type)
        {
            Assert.IsTrue(type.GetCustomAttributes(false).Any(o => o.GetType() == typeof(AuthorizeAttribute)));
        }

        /// <summary>
        /// Assert is authorized helper.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        private static void AssertIsAuthorized(Type type, string action, params Type[] parameters)
        {
            AssertIsAuthorized(type.GetMethod(action, parameters));
        }
    }
}