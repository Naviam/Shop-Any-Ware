// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressesSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The delivery addresses feature steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using NUnit.Framework;

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
    public class DeliveryAddressesSteps
    {
        /// <summary>
        /// The get address controller.
        /// </summary>
        /// <returns>
        /// The TdService.UI.Web.Controllers.AddressController.
        /// </returns>
        public AddressController GetAddressController()
        {
            return new AddressController(
                ScenarioContext.Current.Get<FakeFormsAuthentication>(), ScenarioContext.Current.Get<DeliveryAddressService>());
        }

        /// <summary>
        /// The then i should have the following delivery address as a result.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following delivery address as a result")]
        public void ThenIShouldHaveTheFollowingDeliveryAddressAsAResult(Table table)
        {
            var actual = ScenarioContext.Current.Get<DeliveryAddressViewModel>("actualInstance");
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
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
        /// The then the delivery address view model should have following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the delivery address view model should have following errors")]
        public void ThenTheDeliveryAddressViewModelShouldHaveFollowingErrors(Table table)
        {
            var actual = ScenarioContext.Current.Get<DeliveryAddressViewModel>("actualInstance");
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.BrokenRules, Is.Not.Null);
            table.CompareToSet(actual.BrokenRules);
        }

        /// <summary>
        /// The when i get my own delivery addresses.
        /// </summary>
        [When(@"I get my own delivery addresses")]
        public void WhenIGetMyOwnDeliveryAddresses()
        {
            var controller = this.GetAddressController();
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
            var controller = this.GetAddressController();
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
        /// The when i add the following delivery address.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I add the following delivery address")]
        public void WhenIAddTheFollowingDeliveryAddress(Table table)
        {
            var controller = this.GetAddressController();
            var addressToAdd = table.CreateInstance<DeliveryAddressViewModel>();

            var result = controller.Add(addressToAdd) as JsonNetResult;
            Debug.Assert(result != null, "result != null");
            var actual = result.Data as DeliveryAddressViewModel;

            ScenarioContext.Current.Set(actual, "actualInstance");
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
            var controller = this.GetAddressController();
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
            var controller = this.GetAddressController();
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