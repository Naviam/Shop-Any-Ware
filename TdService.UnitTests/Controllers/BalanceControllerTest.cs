using TdService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TdService.Infrastructure.Authentication;
using System.Web.Mvc;

namespace TdService.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for BalanceControllerTest and is intended
    ///to contain all BalanceControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BalanceControllerTest
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
        ///A test for BalanceController Constructor
        ///</summary>
        [TestMethod()]
        public void BalanceControllerConstructorTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            BalanceController target = new BalanceController(formsAuthentication);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            BalanceController target = new BalanceController(formsAuthentication); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
