// -----------------------------------------------------------------------
// <copyright file="MembershipRepositoryTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Repository
{
    using NUnit.Framework;

    using TdService.Model.Membership;
    using TdService.Repository.MsSql.Repositories;

    /// <summary>
    /// Membership repository for testing.
    /// </summary>
    [TestFixture]
    public class MembershipRepositoryTests
    {
        /// <summary>
        /// Setup tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            new ShopAnyWareTestInitilizer();
        }

        /// <summary>
        /// Should add user with all related info.
        /// </summary>
        [Test]
        public void ShouldAddUserWithAllRelatedInfo()
        {
            // arrange
            var repository = new MembershipRepository();
            var user = new User
                {
                    Email = "v.hatalski@gmail.com",
                    Password = "ruinruin",
                    Profile = new Profile()
                        {
                            FirstName = "Vitali",
                            LastName = "Hatalski",
                            NotifyOnOrderStatusChanged = true,
                            NotifyOnPackageStatusChanged = true
                        }
                };

            // act
            repository.AddShopper(user);
            var actual = repository.GetUser("v.hatalski@gmail.com");

            // assert
            Assert.That(actual.Email, Is.EqualTo(user.Email));
            Assert.That(actual.Password, Is.EqualTo(user.Password));
            Assert.That(actual.Profile.FirstName, Is.EqualTo(user.Profile.FirstName));
            Assert.That(actual.Profile.LastName, Is.EqualTo(user.Profile.LastName));
        }
    }
}