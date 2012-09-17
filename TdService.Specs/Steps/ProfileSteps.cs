// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The profile steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System.Diagnostics;
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;
    using TdService.UI.Web.Controllers;
    using TdService.UI.Web.ViewModels.Account;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// The profile steps.
    /// </summary>
    [Binding]
    public class ProfileSteps
    {
        /// <summary>
        /// The get profile controller.
        /// </summary>
        /// <returns>
        /// The TdService.UI.Web.Controllers.ProfileController.
        /// </returns>
        public ProfileAuthController GetProfileController()
        {
            var membershipService = ScenarioContext.Current.Get<MembershipService>();
            var formsAuthentication = ScenarioContext.Current.Get<FakeFormsAuthentication>();
            return new ProfileAuthController(membershipService, formsAuthentication);
        }

        /// <summary>
        /// The when i go to my profile page.
        /// </summary>
        [When(@"I go to my profile page")]
        public void WhenIGoToMyProfilePage()
        {
            var controller = this.GetProfileController();
            var response = controller.Index() as ViewResult;
            Assert.That(response, Is.Not.Null);
            Debug.Assert(response != null, "response != null");
            var model = response.ViewData.Model as ProfileViewModel;
            ScenarioContext.Current.Set(model);
        }

        /// <summary>
        /// The when i fill the profile form with following data.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [When(@"I fill the profile form with following data")]
        public void WhenIFillTheProfileFormWithFollowingData(Table table)
        {
            var model = table.CreateInstance<ProfileViewModel>();
            var controller = this.GetProfileController();
            var response = controller.Save(model) as JsonNetResult;
            Assert.That(response, Is.Not.Null);
            Debug.Assert(response != null, "response != null");
            var result = response.Data as ProfileViewModel;
            ScenarioContext.Current.Set(result);
        }

        /// <summary>
        /// The then the profile view model should have following errors.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the profile view model should have following errors")]
        public void ThenTheProfileViewModelShouldHaveFollowingErrors(Table table)
        {
            var model = ScenarioContext.Current.Get<ProfileViewModel>();
            table.CompareToSet(model.BrokenRules);
        }

        /// <summary>
        /// The then the profile view model should be as follows.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Then(@"the profile view model should be as follows")]
        public void ThenTheProfileViewModelShouldBeAsFollows(Table table)
        {
            var model = ScenarioContext.Current.Get<ProfileViewModel>();
            table.CompareToInstance(model);
        }
    }
}
