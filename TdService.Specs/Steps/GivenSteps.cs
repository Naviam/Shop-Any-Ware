// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GivenSteps.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The given steps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Repository.MsSql.StaticDataSeed;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;

    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// The given steps.
    /// </summary>
    [Binding]
    public class GivenSteps
    {
        /// <summary>
        /// The before feauture.
        /// </summary>
        [BeforeFeature]
        public static void BeforeEachFeature()
        {
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// The before each scenario.
        /// </summary>
        [BeforeScenario]
        public static void BeforeEachScenario()
        {
            using (var context = new ShopAnyWareSql())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }

                context.Database.Initialize(true);
                context.Database.CreateIfNotExists();
                ////SeedMembership.Populate(context);
            }
        }

        /// <summary>
        /// The before sign up scenarios.
        /// </summary>
        [BeforeScenario("signup", "signin", "profile")]
        public static void BeforeMembershipScenarios()
        {
            var context = new ShopAnyWareSql();
            var userRepository = new UserRepository(context);
            var roleRepository = new RoleRepository(context);
            var profileRepository = new ProfileRepository(context);
            var membershipRepository = new MembershipRepository();

            var logger = new FakeLogger();
            var emailService = new FakeEmailService();
            ScenarioContext.Current.Set(emailService);
            
            var membershipService = new MembershipService(logger, emailService, userRepository, roleRepository, profileRepository, membershipRepository);
            ScenarioContext.Current.Set(membershipService);
        }

        /// <summary>
        /// The before delivery address scenarios.
        /// </summary>
        [BeforeScenario("deliveryaddress")]
        public static void BeforeDeliveryAddressScenarios()
        {
            var addressRepository = new AddressRepository();
            var logger = new FakeLogger();
            var addressService = new DeliveryAddressService(addressRepository, logger);
            ScenarioContext.Current.Set(addressService);
        }

        /// <summary>
        /// The given i have the following delivery addresses.
        /// </summary>
        /// <param name="table">
        /// The table.
        /// </param>
        [Given(@"I have the following delivery addresses")]
        public void GivenIHaveTheFollowingDeliveryAddresses(Table table)
        {
            var addresses = table.CreateSet<DeliveryAddress>();
            var user = ScenarioContext.Current.Get<User>();
            using (var context = new ShopAnyWareSql())
            {
                context.Users.Attach(user);
                if (user.DeliveryAddresses == null)
                {
                    user.DeliveryAddresses = new List<DeliveryAddress>();
                }

                var addedAddresses = addresses.Select(deliveryAddress => context.DeliveryAddresses.Add(deliveryAddress)).ToList();
                context.SaveChanges();

                user.DeliveryAddresses.AddRange(addedAddresses.ToList());
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given there is account with password in role with fullname and.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        [Given(@"there is '(.*)' account with '(.*)' password in role '(.*)' with fullname '(.*)' and '(.*)'")]
        public void GivenThereIsAccountWithPasswordInRoleWithFullnameAnd(
            string email, string password, string roleName, string firstName, string lastName)
        {
            Mapper.AssertConfigurationIsValid();
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }

                var role = context.Roles.SingleOrDefault(r => r.Name == roleName)
                               ?? context.Roles.Add(new Role { Name = roleName });

                var profile = new Profile { FirstName = firstName, LastName = lastName };
                context.Profiles.Add(profile);

                user = new User
                {
                    Email = email,
                    Password = password,
                    Profile = profile,
                    Wallet = new Wallet { Amount = 0m },
                    Roles = new List<Role> { role }
                };

                context.Users.Add(user);
                context.SaveChanges();

                ScenarioContext.Current.Set(user);
            }
        }

        /// <summary>
        /// The given i have not been authenticated yet.
        /// </summary>
        [Given(@"I have not been authenticated yet")]
        public void GivenIHaveNotBeenAuthenticatedYet()
        {
            var formsAuthentication = new FakeFormsAuthentication();
            ScenarioContext.Current.Set(formsAuthentication);
        }

        /// <summary>
        /// The given i am authenticated as.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        [Given(@"I am authenticated as '(.*)'")]
        public void GivenIAmAuthenticatedAs(string email)
        {
            var formsAuthentication = new FakeFormsAuthentication();
            formsAuthentication.SetAuthenticationToken(email, true);
            ScenarioContext.Current.Set(formsAuthentication);
        }
    }
}
