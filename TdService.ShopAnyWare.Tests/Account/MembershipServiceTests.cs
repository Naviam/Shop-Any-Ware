// -----------------------------------------------------------------------
// <copyright file="MembershipServiceTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using NUnit.Framework;

    using TdService.Model.Membership;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging.Membership;
    using TdService.ShopAnyWare.Tests.Orders;

    /// <summary>
    /// This class contains membership service tests.
    /// </summary>
    [TestFixture]
    public class MembershipServiceTests
    {
        /// <summary>
        /// User Repository.
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// The role repository.
        /// </summary>
        private IRoleRepository roleRepository;

        /// <summary>
        /// The profile repository.
        /// </summary>
        private IProfileRepository profileRepository;

        /// <summary>
        /// Initial setup for membership service tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            this.userRepository = new FakeUserRepository();
            this.profileRepository = new FakeProfileRepository();
            this.roleRepository = new FakeRoleRepository();
        }

        /// <summary>
        /// Should be able to get profile if email is valid test.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetProfileIfEmailExists()
        {
            // arrange
            var service = new MembershipService(this.userRepository, this.roleRepository, this.profileRepository);
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
            var service = new MembershipService(this.userRepository, this.roleRepository, this.profileRepository);
            var request = new GetProfileRequest { IdentityToken = "vhatalski2@naviam.com" };

            // act
            var profile = service.GetProfile(request);

            // assert
            Assert.That(profile, Is.Null);
        }
    }
}