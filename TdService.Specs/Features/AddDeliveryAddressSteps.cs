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

    using NUnit.Framework;

    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;

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
        private readonly AddressController addressController;

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
            var context = new ShopAnyWareSql();
            var addressRepository = new AddressRepository(context);
            var userRepository = new UserRepository(context);
            var addressService = new DeliveryAddressService(addressRepository, userRepository);
            this.addressController = new AddressController(new FakeFormsAuthentication(), addressService);
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
            foreach (var tableRow in table.Rows)
            {
                var address = new DeliveryAddressViewModel
                    {
                        Id = int.Parse(tableRow["Id"]),
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
                        Phone = tableRow["Phone"]
                    };
                this.initialDeliveryAddressViewModels.Add(address);
            }
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
                    Id = int.Parse(tableRow["Id"]),
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
                    Phone = tableRow["Phone"]
                };
                this.expectedDeliveryAddressViewModels.Add(address);
            }

            CollectionAssert.IsNotEmpty(this.actualDeliveryAddressViewModels);

            CollectionAssert.AreEquivalent(this.expectedDeliveryAddressViewModels, this.actualDeliveryAddressViewModels);
        }
    }
}