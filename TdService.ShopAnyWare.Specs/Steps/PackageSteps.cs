// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs.Steps
{
    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.ShopAnyWare.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Package;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The package steps.
    /// </summary>
    [Binding]
    public class PackageSteps
    {
        /// <summary>
        /// The get packages controller.
        /// </summary>
        /// <returns>
        /// The TdService.UI.Web.Controllers.PackagesController.
        /// </returns>
        public PackagesController GetPackagesController()
        {
            var formsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            var packagesService = ScenarioContext.Current.Get<PackagesService>();
            return new PackagesController(packagesService, formsAuthentication);
        }

        /// <summary>
        /// The when i set package name as.
        /// </summary>
        /// <param name="packageName">s
        /// The package name.
        /// </param>
        [When(@"I set package name as '(.*)'")]
        public void WhenISetPackageNameAs(string packageName)
        {
            var contoller = this.GetPackagesController();
            var result = contoller.Add(packageName) as JsonNetResult;
            Assert.That(result, Is.Not.Null);
            if (result != null)
            {
                var actual = result.Data as PackageViewModel;
                ScenarioContext.Current.Set(actual);
            }
        }

        /// <summary>
        /// The then i should have the following packages as a result.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"I should have the following packages as a result")]
        public void ThenIShouldHaveTheFollowingPackagesAsAResult(Table table)
        {
            var actual = ScenarioContext.Current.Get<PackageViewModel>();
            Assert.That(actual, Is.Not.Null);
            table.CompareToInstance(actual);
        }
    }
}
