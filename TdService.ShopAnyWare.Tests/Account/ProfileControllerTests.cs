// -----------------------------------------------------------------------
// <copyright file="ProfileControllerTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using System.Web.Mvc;

    using NUnit.Framework;

    using TdService.Controllers;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Profile controller tests.
    /// </summary>
    [TestFixture]
    public class ProfileControllerTests
    {
        /// <summary>
        /// Gets or sets membership service.
        /// </summary>
        private IMembershipService MembershipService { get; set; }

        /// <summary>
        /// Gets or sets Forms Authentication.
        /// </summary>
        private IFormsAuthentication FormsAuthentication { get; set; }

        /// <summary>
        /// Initial setup for profile controller tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.MembershipService = new FakeMembershipService();
            this.FormsAuthentication = new FakeFormsAuthentication();
        }

        /// <summary>
        /// Should see profile form test.
        /// </summary>
        [Test]
        public void ShouldSeeProfileForm()
        {
            // arrange
            var controller = new ProfileController(this.MembershipService, this.FormsAuthentication);

            // act
            var actual = (ViewResult)controller.Index();

            // assert
            Assert.That(actual.ViewName, Is.EqualTo(string.Empty));
            Assert.That(actual.Model, Is.TypeOf(typeof(ProfileView)));
        }

        /// <summary>
        /// Should be able to update profile test.
        /// </summary>
        [Test]
        public void ShouldBeAbleToCallSaveProfileMethod()
        {
            // arrange
            var controller = new ProfileController(this.MembershipService, this.FormsAuthentication);
            var profileView = new ProfileView
                {
                    FirstName = "Vitali",
                    LastName = "Hatalski",
                    NotifyOnOrderStatusChange = true,
                    NotifyOnPackageStatusChange = true
                };

            // act
            var actual = ((JsonResult)controller.Save(profileView)).Data as ProfileView;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                Assert.That(actual.MessageType, Is.EqualTo("success"));
            }
        }

        /// <summary>
        /// Should not be able to save invalid profile view test.
        /// </summary>
        [Test]
        public void ShouldNotBeAbleToSaveInvalidProfileView()
        {
            // arrange
            var controller = new ProfileController(this.MembershipService, this.FormsAuthentication);
            var profileView = new ProfileView
            {
                FirstName = "Vitali",
                LastName = string.Empty,
                NotifyOnOrderStatusChange = true,
                NotifyOnPackageStatusChange = true
            };

            controller.ModelState.AddModelError("key", "model is invalid");

            // act
            var actual = ((JsonResult)controller.Save(profileView)).Data as ProfileView;

            // assert
            Assert.That(actual, Is.Not.Null);
            if (actual != null)
            {
                Assert.That(actual.MessageType, Is.EqualTo("error"));
            }
        }
    }
}