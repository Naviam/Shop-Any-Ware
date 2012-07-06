// -----------------------------------------------------------------------
// <copyright file="MembershipRepositoryTests.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Repository
{
    using System.Data.Entity;

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
            Database.SetInitializer(new ShopAnyWareTestInitilizer());
        }

        /// <summary>
        /// Should add user with all related info.
        /// </summary>
        [Test]
        public void ShouldAddUserWithProfile()
        {
            // arrange
            var repository = new MembershipRepository();
            var user = new User(repository)
                {
                    Email = "v.hatalski@gmail.com",
                    Password = "ruinruin",
                    Profile = new Profile
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
            Assert.That(actual.Profile.NotifyOnOrderStatusChanged, Is.EqualTo(user.Profile.NotifyOnOrderStatusChanged));
            Assert.That(actual.Profile.NotifyOnPackageStatusChanged, Is.EqualTo(user.Profile.NotifyOnPackageStatusChanged));
        }

        /// <summary>
        /// Should be able to update profile of an existing user.
        /// </summary>
        [Test]
        public void ShouldUpdateExistingUserProfile()
        {
            // arrange
            var repository = new MembershipRepository();
            var user = new User(repository)
            {
                Email = "vhatalski@naviam.com",
                Password = "ruinruin",
                Profile = new Profile
                {
                    FirstName = "Alex",
                    LastName = "Smirnov",
                    NotifyOnOrderStatusChanged = false,
                    NotifyOnPackageStatusChanged = false
                }
            };

            repository.UpdateProfile(user.Email, user.Profile);
            var actual = repository.GetUser("vhatalski@naviam.com");

            // assert
            Assert.That(actual.Email, Is.EqualTo(user.Email));
            Assert.That(actual.Password, Is.EqualTo(user.Password));
            Assert.That(actual.Profile.FirstName, Is.EqualTo(user.Profile.FirstName));
            Assert.That(actual.Profile.LastName, Is.EqualTo(user.Profile.LastName));
            Assert.That(actual.Profile.NotifyOnOrderStatusChanged, Is.EqualTo(user.Profile.NotifyOnOrderStatusChanged));
            Assert.That(actual.Profile.NotifyOnPackageStatusChanged, Is.EqualTo(user.Profile.NotifyOnPackageStatusChanged));
        }
    }
}