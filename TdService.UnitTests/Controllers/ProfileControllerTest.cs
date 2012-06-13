// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileControllerTest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This is a test class for ProfileControllerTest and is intended
//   to contain all ProfileControllerTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UnitTests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// This is a test class for ProfileControllerTest and is intended
    /// to contain all ProfileControllerTest Unit Tests
    /// </summary>
    [TestClass]
    public class ProfileControllerTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext)
        // {
        // }
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup()
        // {
        // }
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize()
        // {
        // }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup()
        // {
        // }
        #endregion

        /// <summary>
        /// A test for Save
        /// </summary>
        [TestMethod]
        public void SaveTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            var target = new ProfileController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ProfileView profileView = null; // TODO: Initialize to an appropriate value
            JsonResult expected = null; // TODO: Initialize to an appropriate value
            JsonResult actual;
            actual = target.Save(profileView);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for Index
        /// </summary>
        [TestMethod]
        public void IndexTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            var target = new ProfileController(membershipService, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for ProfileController Constructor
        /// </summary>
        [TestMethod]
        public void ProfileControllerConstructorTest()
        {
            IMembershipService membershipService = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            var target = new ProfileController(membershipService, formsAuthentication);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}