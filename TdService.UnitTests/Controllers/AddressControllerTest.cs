using TdService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TdService.Infrastructure.Authentication;
using TdService.Services.Interfaces;
using TdService.Services.ViewModels.Account;
using System.Web.Mvc;

namespace TdService.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for AddressControllerTest and is intended
    ///to contain all AddressControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddressControllerTest
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
        ///A test for AddressController Constructor
        ///</summary>
        [TestMethod()]
        public void AddressControllerConstructorTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            DeliveryAddressDetails view = null; // TODO: Initialize to an appropriate value
            JsonResult expected = null; // TODO: Initialize to an appropriate value
            JsonResult actual;
            actual = target.Add(view);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Details
        ///</summary>
        [TestMethod()]
        public void DetailsTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            int addressId = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Details(addressId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            JsonResult expected = null; // TODO: Initialize to an appropriate value
            JsonResult actual;
            actual = target.Remove();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            JsonResult expected = null; // TODO: Initialize to an appropriate value
            JsonResult actual;
            actual = target.Update();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Warehouse
        ///</summary>
        [TestMethod()]
        public void WarehouseTest()
        {
            IFormsAuthentication formsAuthentication = null; // TODO: Initialize to an appropriate value
            IAddressService addressService = null; // TODO: Initialize to an appropriate value
            AddressController target = new AddressController(formsAuthentication, addressService); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Warehouse();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
