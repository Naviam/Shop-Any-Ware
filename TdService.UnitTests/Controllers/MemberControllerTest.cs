using TdService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TdService.Model.Orders;
using TdService.Infrastructure.Authentication;
using System.Web.Mvc;

namespace TdService.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for MemberControllerTest and is intended
    ///to contain all MemberControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemberControllerTest
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
        ///A test for MemberController Constructor
        ///</summary>
        [TestMethod()]
        public void MemberControllerConstructorTest()
        {
            IOrderRepository repo = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            MemberController target = new MemberController(repo, formsAuthentication);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Dashboard
        ///</summary>
        [TestMethod()]
        public void DashboardTest()
        {
            IOrderRepository repo = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            MemberController target = new MemberController(repo, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Dashboard();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Home
        ///</summary>
        [TestMethod()]
        public void HomeTest()
        {
            IOrderRepository repo = null; // TODO: Initialize to an appropriate value
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            MemberController target = new MemberController(repo, formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Home();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
