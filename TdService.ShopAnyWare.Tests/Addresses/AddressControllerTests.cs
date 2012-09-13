namespace TdService.ShopAnyWare.Tests.Addresses
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using AutoMapper;

    using NUnit.Framework;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.ShopAnyWare.Tests.Account;
    using TdService.ShopAnyWare.Tests.Helpers;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    [TestFixture]
    [Category("Controller")]
    public class AddressControllerTests
    {
        /// <summary>
        /// The forms authentication.
        /// </summary>
        private IFormsAuthentication formsAuthentication;

        /// <summary>
        /// The address service.
        /// </summary>
        private IAddressService addressService;

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            AutoMapperConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();

            this.formsAuthentication = new FakeFormsAuthentication();
            this.formsAuthentication.SetAuthenticationToken("vhatalski@naviam.com", true);
            this.addressService = new FakeAddressService();
        }

        /// <summary>
        /// The should be able to call get delivery addresses only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCallGetDeliveryAddressesOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(AddressController), "Get");
        }

        /// <summary>
        /// The should be able to call add delivery address only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCallAddDeliveryAddressOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(AddressController), "Add", typeof(DeliveryAddressViewModel));
        }

        /// <summary>
        /// The should be able to call remove delivery address only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCallRemoveDeliveryAddressOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(AddressController), "Remove", typeof(int));
        }

        /// <summary>
        /// The should be able to call update delivery address only if authorized.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCallUpdateDeliveryAddressOnlyIfAuthorized()
        {
            TestHelper.AssertIsAuthorized(typeof(AddressController), "Update", typeof(DeliveryAddressViewModel));
        }

        /// <summary>
        /// The should return json collection of user addresses.
        /// </summary>
        [Test]
        public void ShouldReturnJsonCollectionOfUserAddresses()
        {
            // arrange
            var controller = new AddressController(this.formsAuthentication, this.addressService);

            // act
            var actual = controller.Get() as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as List<DeliveryAddressViewModel>;
            Debug.Assert(model != null, "model != null");
            Assert.That(model.Count, Is.GreaterThan(0));
        }

        /// <summary>
        /// The should be able to add delivery address.
        /// </summary>
        [Test]
        public void ShouldBeAbleToAddDeliveryAddress()
        {
            // arrange
            var controller = new AddressController(this.formsAuthentication, this.addressService);
            var viewModel = new DeliveryAddressViewModel
                {
                    Id = 0,
                    AddressName = "Test 1",
                    AddressLine1 = "street",
                    AddressLine2 = "flat",
                    City = "Minsk",
                    Country = "Belarus",
                    Region = null,
                    State = null,
                    FirstName = "Vitali",
                    LastName = "Hatalski",
                    Phone = null,
                    ZipCode = "1233",
                    AddressLine3 = null
                };

            // act
            var actual = controller.Add(viewModel) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as DeliveryAddressViewModel;
            Debug.Assert(model != null, "model != null");
            Assert.That(model.MessageType, Is.EqualTo("Success"));
            Assert.That(model.Id, Is.GreaterThan(0));
            Assert.That(model.AddressName, Is.EqualTo("Test 1"));
            Assert.That(model.AddressLine1, Is.EqualTo("street"));
            Assert.That(model.AddressLine2, Is.EqualTo("flat"));
            Assert.That(model.AddressLine3, Is.Null);
            Assert.That(model.City, Is.EqualTo("Minsk"));
            Assert.That(model.Country, Is.EqualTo("Belarus"));
            Assert.That(model.Region, Is.Null);
            Assert.That(model.State, Is.Null);
            Assert.That(model.FirstName, Is.EqualTo("Vitali"));
            Assert.That(model.LastName, Is.EqualTo("Hatalski"));
            Assert.That(model.Phone, Is.Null);
            Assert.That(model.ZipCode, Is.EqualTo("1233"));
        }

        /// <summary>
        /// The should be able to update delivery address.
        /// </summary>
        [Test]
        public void ShouldBeAbleToUpdateDeliveryAddress()
        {
            // arrange
            var controller = new AddressController(this.formsAuthentication, this.addressService);
            var viewModel = new DeliveryAddressViewModel
            {
                Id = 1,
                AddressName = "Test 1",
                AddressLine1 = "street",
                AddressLine2 = "flat",
                City = "Minsk",
                Country = "Belarus",
                Region = null,
                State = null,
                FirstName = "Vitali",
                LastName = "Hatalski",
                Phone = null,
                ZipCode = "1233",
                AddressLine3 = null
            };

            // act
            var actual = controller.Update(viewModel) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as DeliveryAddressViewModel;
            Debug.Assert(model != null, "model != null");
            Assert.That(model.MessageType, Is.EqualTo("Success"));
            Assert.That(model.Id, Is.EqualTo(1));
            Assert.That(model.AddressName, Is.EqualTo("Test 1"));
            Assert.That(model.AddressLine1, Is.EqualTo("street"));
            Assert.That(model.AddressLine2, Is.EqualTo("flat"));
            Assert.That(model.AddressLine3, Is.Null);
            Assert.That(model.City, Is.EqualTo("Minsk"));
            Assert.That(model.Country, Is.EqualTo("Belarus"));
            Assert.That(model.Region, Is.Null);
            Assert.That(model.State, Is.Null);
            Assert.That(model.FirstName, Is.EqualTo("Vitali"));
            Assert.That(model.LastName, Is.EqualTo("Hatalski"));
            Assert.That(model.Phone, Is.Null);
            Assert.That(model.ZipCode, Is.EqualTo("1233"));
        }

        /// <summary>
        /// The should be able to remove delivery address.
        /// </summary>
        [Test]
        public void ShouldBeAbleToRemoveDeliveryAddress()
        {
            // arrange
            var controller = new AddressController(this.formsAuthentication, this.addressService);
            const int AddressIdToRemove = 1;

            // act
            var actual = controller.Remove(AddressIdToRemove) as JsonNetResult;

            // assert
            Assert.That(actual, Is.Not.Null);
            Debug.Assert(actual != null, "actual != null");
            var model = actual.Data as DeliveryAddressViewModel;
            Debug.Assert(model != null, "model != null");
            Assert.That(model.MessageType, Is.EqualTo("Success"));
            Assert.That(model.Id, Is.EqualTo(1));
        }
    }
}