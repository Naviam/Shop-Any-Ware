// -----------------------------------------------------------------------
// <copyright file="MembershipServiceTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Services
{
    using NUnit.Framework;

    using TdService.Model.Membership;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// This class contains membership service tests.
    /// </summary>
    [TestFixture]
    public class MembershipServiceTests
    {
        /// <summary>
        /// Gets or sets Membership Repository.
        /// </summary>
        private IMembershipRepository MembershipRepository { get; set; }

        /// <summary>
        /// Initial setup for membership service tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.MembershipRepository = new FakeMembershipRepository();
        }

        /// <summary>
        /// Should be able to get profile if email is valid test.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetProfileIfEmailExists()
        {
            // arrange
            var service = new MembershipService(this.MembershipRepository);
            var request = new GetProfileRequest { IdentityToken = "vhatalski@naviam.com" };

            // act
            var profile = service.GetProfile(request);

            // assert
            Assert.That(profile.FirstName, Is.EqualTo("Vitali"));
        }

        /// <summary>
        /// Should not be able to get profile if email does not exist.
        /// </summary>
        [Test]
        public void ShouldNotBeAbleToGetProfileIfEmailDoesNotExist()
        {
            // arrange
            var service = new MembershipService(this.MembershipRepository);
            var request = new GetProfileRequest { IdentityToken = "vhatalski2@naviam.com" };

            // act
            var profile = service.GetProfile(request);

            // assert
            Assert.That(profile, Is.Null);
        }
    }
}