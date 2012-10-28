// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageItemsSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package items steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using TechTalk.SpecFlow;

    /// <summary>
    /// The package items steps.
    /// </summary>
    [Binding]
    public class PackageItemsSteps
    {
        /// <summary>
        /// The when i add item to package with the following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I add item to package with the following data")]
        public void WhenIAddItemToPackageWithTheFollowingData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// The then i should have the following package items.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following package items")]
        public void ThenIShouldHaveTheFollowingPackageItems(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
