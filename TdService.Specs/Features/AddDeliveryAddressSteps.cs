// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDeliveryAddressSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add delivery address steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Features
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The add delivery address steps.
    /// </summary>
    [Binding]
    public class AddDeliveryAddressSteps
    {
        /// <summary>
        /// The initial delivery address view models.
        /// </summary>
        private readonly List<DeliveryAddressViewModel> initialDeliveryAddressViewModels;

        /// <summary>
        /// The expected delivery address view models.
        /// </summary>
        private readonly List<DeliveryAddressViewModel> expectedDeliveryAddressViewModels;

        /// <summary>
        /// The actual delivery address view models.
        /// </summary>
        private readonly List<DeliveryAddressViewModel> actualDeliveryAddressViewModels;

        /// <summary>
        /// The address controller.
        /// </summary>
        private AddressController addressController;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddDeliveryAddressSteps"/> class.
        /// </summary>
        public AddDeliveryAddressSteps()
        {
            AutoMapperConfiguration.Configure();
            this.expectedDeliveryAddressViewModels = new List<DeliveryAddressViewModel>();
            this.actualDeliveryAddressViewModels = new List<DeliveryAddressViewModel>();
            this.initialDeliveryAddressViewModels = new List<DeliveryAddressViewModel>();
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
        }

        /// <summary>
        /// The given i am a shopper with email address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        [Given(@"I am a shopper with '(.*)' email address")]
// ReSharper disable InconsistentNaming
        public void GivenIAmAShopperWithEmailAddress(string email)
// ReSharper restore InconsistentNaming
        {
            var addressRepository = new AddressRepository();
            var addressService = new DeliveryAddressService(addressRepository);
            var formsAuthentication = new FakeFormsAuthentication();
            formsAuthentication.SetAuthenticationToken(email, true);
            this.addressController = new AddressController(formsAuthentication, addressService);
        }


        /// <summary>
        /// The given i have entered the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have entered the following delivery addresses")]
        public void GivenIHaveEnteredTheFollowingDeliveryAddresses(Table table)
        {
            var addresses = table.CreateSet<DeliveryAddressViewModel>();
            this.initialDeliveryAddressViewModels.AddRange(addresses);
            ////foreach (var tableRow in table.Rows)
            ////{
            ////    var address = new DeliveryAddressViewModel
            ////        {
            ////            AddressName = tableRow["AddressName"],
            ////            FirstName = tableRow["FirstName"],
            ////            LastName = tableRow["LastName"],
            ////            AddressLine1 = tableRow["AddressLine1"],
            ////            AddressLine2 = tableRow["AddressLine2"],
            ////            AddressLine3 = tableRow["AddressLine3"],
            ////            City = tableRow["City"],
            ////            Country = tableRow["Country"],
            ////            State = tableRow["State"],
            ////            Region = tableRow["Region"],
            ////            ZipCode = tableRow["ZipCode"],
            ////            Phone = tableRow["Phone"],
            ////            MessageType = tableRow["MessageType"]
            ////        };
            ////    this.initialDeliveryAddressViewModels.Add(address);
            ////}
        }

        /// <summary>
        /// The given i have the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have the following delivery addresses")]
        public void GivenIHaveTheFollowingDeliveryAddresses(Table table)
        {
            var addresses = table.CreateSet<DeliveryAddressViewModel>();
            this.initialDeliveryAddressViewModels.AddRange(addresses);
        }

        /// <summary>
        /// The when addresses go to conroller.
        /// </summary>
        [When(@"addresses go to conroller")]
        public void WhenAddressesGoToConroller()
        {
            foreach (var deliveryAddressViewModel in this.initialDeliveryAddressViewModels)
            {
                var result = this.addressController.Add(deliveryAddressViewModel) as JsonNetResult;
                Debug.Assert(result != null, "result != null");
                var model = result.Data as DeliveryAddressViewModel;
                this.actualDeliveryAddressViewModels.Add(model);
            }
        }

        /// <summary>
        /// The then the result should be as the following.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the result should be as the following")]
        public void ThenTheResultShouldBeAsTheFollowing(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var address = new DeliveryAddressViewModel
                {
                    AddressName = tableRow["AddressName"],
                    FirstName = tableRow["FirstName"],
                    LastName = tableRow["LastName"],
                    AddressLine1 = tableRow["AddressLine1"],
                    AddressLine2 = tableRow["AddressLine2"],
                    AddressLine3 = tableRow["AddressLine3"],
                    City = tableRow["City"],
                    Country = tableRow["Country"],
                    State = tableRow["State"],
                    Region = tableRow["Region"],
                    ZipCode = tableRow["ZipCode"],
                    Phone = tableRow["Phone"],
                    MessageType = tableRow["MessageType"]
                };
                this.expectedDeliveryAddressViewModels.Add(address);
            }

            CollectionAssert.IsNotEmpty(this.actualDeliveryAddressViewModels);

            foreach (var actualDeliveryAddressViewModel in this.actualDeliveryAddressViewModels)
            {
                Assert.That(actualDeliveryAddressViewModel.Id, Is.GreaterThan(0));
            }

            CollectionAssert.AreEqual(
                this.expectedDeliveryAddressViewModels,
                this.actualDeliveryAddressViewModels,
                new DeliveryAddressViewModelComparer());
        }
    }
}