// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountControllerTest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This is a test class for AccountControllerTest and is intended
//   to contain all AccountControllerTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UnitTests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// This is a test class for AccountControllerTest and is intended
    /// to contain all AccountControllerTest Unit Tests
    /// </summary>
    [TestClass]
    public class AccountControllerTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets or sets AccountController.
        /// </summary>
        private static AccountController AccountController { get; set; }

        #region Additional test attributes

        /// <summary>
        /// You can use the following additional attributes as you write your tests:
        /// Use ClassInitialize to run code before running the first test in the class
        /// </summary>
        /// <param name="testContext">
        /// The test context.
        /// </param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            IMembershipService membershipService = new FakeMembershipService();
            IFormsAuthentication formsAuthentication = new FakeFormsAuthentication();
            AccountController = new AccountController(membershipService, formsAuthentication);
        }

        /// <summary>
        /// Use ClassCleanup to run code after all tests in a class have run
        /// </summary>
        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize()
        // {
        // }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup()
        // {
        // }
        #endregion

        /// <summary>
        /// A test for AccountController Constructor
        /// </summary>
        [TestMethod]
        public void AccountControllerConstructorTest()
        {
            Assert.IsNotNull(AccountController);
        }

        /// <summary>
        /// A test for Forgot
        /// </summary>
        [TestMethod]
        public void ForgotTest()
        {
            ActionResult expected = null;
            var actual = (ViewResult)AccountController.Forgot();
            Assert.AreEqual(expected, actual.ViewData[""]);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for SignIn
        /// </summary>
        [TestMethod]
        public void SignInTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignIn();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for SignIn
        /// </summary>
        [TestMethod]
        public void SignInTest1()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
                // TODO: Initialize to an appropriate value
            SignInView request = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignIn(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for SignOut
        /// </summary>
        [TestMethod]
        public void SignOutTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignOut();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for SignUp
        /// </summary>
        [TestMethod]
        public void SignUpTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignUp();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for SignUp
        /// </summary>
        [TestMethod]
        public void SignUpTest1()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
                // TODO: Initialize to an appropriate value
            SignUpView request = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignUp(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }

    /// <summary>
    /// Mocking forms authentication
    /// </summary>
    public class FakeFormsAuthentication : IFormsAuthentication
    {
        #region Implementation of IFormsAuthentication

        /// <summary>
        /// Set authentication token.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="persist">
        /// The persist cookie flag.
        /// </param>
        public void SetAuthenticationToken(string token, bool persist)
        {
        }

        /// <summary>
        /// Get authentication token.
        /// </summary>
        /// <returns>
        /// Authentication token.
        /// </returns>
        public string GetAuthenticationToken()
        {
            return null;
        }

        /// <summary>
        /// Sign out.
        /// </summary>
        public void SignOut()
        {
        }

        #endregion
    }

    /// <summary>
    /// Fake Membership Service class.
    /// </summary>
    public class FakeMembershipService : IMembershipService
    {
        #region Implementation of IMembershipService

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            return null;
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The login user.
        /// </returns>
        public LoginUserResponse LoginUser(LoginUserRequest request)
        {
            return new LoginUserResponse();
        }

        /// <summary>
        /// Validate user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user valid.
        /// </returns>
        public ValidateUserResponse ValidateUser(ValidateUserRequest request)
        {
            return new ValidateUserResponse();
        }

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get user response object.
        /// </returns>
        public GetUserResponse GetUser(GetUserRequest request)
        {
            return new GetUserResponse();
        }

        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get profile response object.
        /// </returns>
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            return new GetProfileResponse();
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="profileView">
        /// The profile view.
        /// </param>
        /// <returns>
        /// The update profile.
        /// </returns>
        public UpdateProfileResponse UpdateProfile(ProfileView profileView)
        {
            return new UpdateProfileResponse();
        }

        #endregion
    }
}