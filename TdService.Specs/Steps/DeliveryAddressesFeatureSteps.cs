// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressesFeatureSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The delivery addresses feature steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    using NUnit.Framework;

    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The delivery addresses feature steps.
    /// </summary>
    [Binding]
    public class DeliveryAddressesFeatureSteps
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressesFeatureSteps"/> class.
        /// </summary>
        public DeliveryAddressesFeatureSteps()
        {
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// The reset database.
        /// </summary>
        public void ReinitDatabase()
        {
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
            using (var context = new ShopAnyWareSql())
            {
                context.Database.Delete();
                context.Database.Initialize(true);
                context.Database.CreateIfNotExists();
            }
        }

        /// <summary>
        /// The populate with addresses.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="addresses">
        /// The addresses.
        /// </param>
        public void PopulateWithAddresses(string email, IEnumerable<DeliveryAddress> addresses)
        {
            using (var context = new ShopAnyWareSql())
            {
                var shopper = context.Users.Include("DeliveryAddresses").Include("Profile").Include("Wallet").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (shopper == null)
                {
                    var profile = new Profile { FirstName = "Vitali", LastName = "Hatalski" };

                    context.Profiles.Add(profile);
                    context.SaveChanges();

                    shopper = new User { Email = email, Password = "11111111", Profile = profile, Wallet = new Wallet { Amount = 0m } };

                    shopper = context.Users.Add(shopper);
                    context.SaveChanges();
                }

                Debug.Assert(shopper != null, "shopper != null");
                if (shopper.DeliveryAddresses == null)
                {
                    shopper.DeliveryAddresses = new List<DeliveryAddress>();
                }

                var addedAddresses = addresses.Select(deliveryAddress => context.DeliveryAddresses.Add(deliveryAddress)).ToList();
                var errors = context.GetValidationErrors();
                context.SaveChanges();
                var errors2 = context.GetValidationErrors();

                shopper.DeliveryAddresses.AddRange(addedAddresses.ToList());
                context.Entry(shopper).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The given i have email address.
        /// </summary>
        /// <param name="p0">
        /// The p 0.
        /// </param>
        [Given(@"I have '(.*)' email address")]
        public void GivenIHaveEmailAddress(string p0)
        {
            this.ReinitDatabase();
            var addressRepository = new AddressRepository();
            var addressService = new DeliveryAddressService(addressRepository);
            var fakeFormsAuthentication = new FakeFormsAuthentication();
            fakeFormsAuthentication.SetAuthenticationToken(p0, true);
            ScenarioContext.Current.Set(p0, "email");
            var addressController = new AddressController(fakeFormsAuthentication, addressService);
            ScenarioContext.Current.Set(addressController);
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
            var addresses = table.CreateSet<DeliveryAddress>();
            this.PopulateWithAddresses(ScenarioContext.Current.Get<string>("email"), addresses);
        }

        /// <summary>
        /// The then i should have the following delivery addresses as a result.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following delivery addresses as a result")]
        public void ThenIShouldHaveTheFollowingDeliveryAddressesAsAResult(Table table)
        {
            var actual = ScenarioContext.Current.Get<List<DeliveryAddressViewModel>>("actual");
            Assert.That(actual, Is.Not.Empty);
            table.CompareToSet(actual);
        }

        /// <summary>
        /// The when i get my own delivery addresses.
        /// </summary>
        [When(@"I get my own delivery addresses")]
        public void WhenIGetMyOwnDeliveryAddresses()
        {
            var controller = ScenarioContext.Current.Get<AddressController>();
            var result = controller.Get() as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as List<DeliveryAddressViewModel>;
                ScenarioContext.Current.Set(actual, "actual");
            }
        }

        /// <summary>
        /// The when i add the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I add the following delivery addresses")]
        public void WhenIAddTheFollowingDeliveryAddresses(Table table)
        {
            var controller = ScenarioContext.Current.Get<AddressController>();
            var addressesToAdd = table.CreateSet<DeliveryAddressViewModel>();
            var actual = new List<DeliveryAddressViewModel>();

            foreach (var deliveryAddressViewModel in addressesToAdd)
            {
                var result = controller.Add(deliveryAddressViewModel) as JsonNetResult;
                Debug.Assert(result != null, "result != null");
                var model = result.Data as DeliveryAddressViewModel;
                actual.Add(model);
            }

            ScenarioContext.Current.Set(actual, "actual");
        }

        /// <summary>
        /// The when i edit the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I edit the following delivery addresses")]
        public void WhenIEditTheFollowingDeliveryAddresses(Table table)
        {
            var controller = ScenarioContext.Current.Get<AddressController>();
            var addressesToEdit = table.CreateSet<DeliveryAddressViewModel>();
            var actual = new List<DeliveryAddressViewModel>();

            foreach (var deliveryAddressViewModel in addressesToEdit)
            {
                var result = controller.Update(deliveryAddressViewModel) as JsonNetResult;
                Debug.Assert(result != null, "result != null");
                var model = result.Data as DeliveryAddressViewModel;
                actual.Add(model);
            }

            ScenarioContext.Current.Set(actual, "actual");
        }

        /// <summary>
        /// The when i remove the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I remove the following delivery addresses")]
        public void WhenIRemoveTheFollowingDeliveryAddresses(Table table)
        {
            var controller = ScenarioContext.Current.Get<AddressController>();
            var actual = new List<DeliveryAddressViewModel>();

            foreach (var row in table.Rows)
            {
                string id;
                row.TryGetValue("Id", out id);
                Assert.That(id, Is.Not.Null);
                Debug.Assert(id != null, "id != null");
                var result = controller.Remove(int.Parse(id)) as JsonNetResult;
                Debug.Assert(result != null, "result != null");
                var model = result.Data as DeliveryAddressViewModel;
                actual.Add(model);
            }

            ScenarioContext.Current.Set(actual, "actual");
        }
    }
}