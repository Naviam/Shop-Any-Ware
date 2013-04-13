// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopperPackagesSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shopper packages steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using TechTalk.SpecFlow;

    /// <summary>
    /// The shopper packages steps.
    /// </summary>
    [Binding]
    public class ShopperPackagesSteps
    {
        /// <summary>
        /// The when i update delivery address to of package.
        /// </summary>
        /// <param name="deliveryAddressId">
        /// The delivery Address Id.
        /// </param>
        /// <param name="packageId">
        /// The package Id.
        /// </param>
        [When(@"I update delivery address to '(.*)' of package '(.*)'")]
        public void WhenIUpdateDeliveryAddressToOfPackage(int deliveryAddressId, int packageId)
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// The when i remove packages with the ids as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I remove packages with the ids as follows")]
        public void WhenIRemovePackagesWithTheIdsAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
