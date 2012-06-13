using TdService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TdService.Model.Membership;
using TdService.Infrastructure.Authentication;
using System.Web.Mvc;

namespace TdService.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for AdminControllerTest and is intended
    ///to contain all AdminControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdminControllerTest
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
        ///A test for Dashboard
        ///</summary>
        [TestMethod()]
        public void DashboardTest()
        {
            IMembershipRepository membershipRepository = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AdminController target = new AdminController(membershipRepository, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Dashboard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AdminController Constructor
        ///</summary>
        [TestMethod()]
        public void AdminControllerConstructorTest()
        {
            IMembershipRepository membershipRepository = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            AdminController target = new AdminController(membershipRepository, formsAuthentication);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
