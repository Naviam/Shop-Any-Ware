using TdService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TdService.Services.Interfaces;
using TdService.Infrastructure.Authentication;
using System.Web.Mvc;
using TdService.Services.ViewModels.Account;

namespace TdService.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for AccountControllerTest and is intended
    ///to contain all AccountControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AccountController Constructor
        ///</summary>
        [TestMethod()]
        public void AccountControllerConstructorTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Forgot
        ///</summary>
        [TestMethod()]
        public void ForgotTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Forgot();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SignIn
        ///</summary>
        [TestMethod()]
        public void SignInTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignIn();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SignIn
        ///</summary>
        [TestMethod()]
        public void SignInTest1()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            SignInView request = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignIn(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SignOut
        ///</summary>
        [TestMethod()]
        public void SignOutTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignOut();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SignUp
        ///</summary>
        [TestMethod()]
        public void SignUpTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignUp();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SignUp
        ///</summary>
        [TestMethod()]
        public void SignUpTest1()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AccountController target = new AccountController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            SignUpView request = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.SignUp(request);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
