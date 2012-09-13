// -----------------------------------------------------------------------
// <copyright file="MembershipServiceTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using AutoMapper;

    using NUnit.Framework;

    using TdService.Infrastructure.Email;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;
    using TdService.ShopAnyWare.Tests.Mocks;
    using TdService.ShopAnyWare.Tests.Orders;
    using TdService.UI.Web;

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
        /// The membership repository.
        /// </summary>
        private IMembershipRepository membershipRepository;

        /// <summary>
        /// The profile repository.
        /// </summary>
        private IProfileRepository profileRepository;

        /// <summary>
        /// The logger.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// The email service.
        /// </summary>
        private IEmailService emailService;

        /// <summary>
        /// Initial setup for membership service tests.
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();

            this.userRepository = new FakeUserRepository();
            this.profileRepository = new FakeProfileRepository();
            this.roleRepository = new FakeRoleRepository();
            this.membershipRepository = new MembershipRepository();
            this.emailService = new FakeEmailService();
            this.logger = new FakeLogger();
        }

        /// <summary>
        /// Should be able to get profile if email is valid test.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetProfileIfEmailExists()
        {
            // arrange
            var service = new MembershipService(this.logger, this.emailService, this.userRepository, this.roleRepository, this.profileRepository, this.membershipRepository);
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
            var service = new MembershipService(this.logger, this.emailService, this.userRepository, this.roleRepository, this.profileRepository, this.membershipRepository);
            var request = new GetProfileRequest { IdentityToken = "vhatalski2@naviam.com" };

            // act
            var profile = service.GetProfile(request);

            // assert
            Assert.That(profile.MessageType, Is.EqualTo(MessageType.Error));
        }
    }
}