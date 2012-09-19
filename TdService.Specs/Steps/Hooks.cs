﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hooks.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The hooks.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Steps
{
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Specs.Fakes;
    using TdService.UI.Web;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The hooks.
    /// </summary>
    [Binding]
    public class Hooks
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
        [BeforeScenario("deliveryaddresses")]
        public static void BeforeDeliveryAddressScenarios()
        {
            var addressRepository = new AddressRepository();
            var logger = new FakeLogger();
            var addressService = new DeliveryAddressService(addressRepository, logger);
            ScenarioContext.Current.Set(addressService);
        }

        /// <summary>
        /// The before order scenarios.
        /// </summary>
        [BeforeScenario("orders")]
        public static void BeforeOrderScenarios()
        {
            var context = new ShopAnyWareSql();
            var userRepository = new UserRepository(context);
            var orderRepository = new OrderRepository();
            var logger = new FakeLogger();
            var orderService = new OrderService(orderRepository, logger);
            ScenarioContext.Current.Set(orderService);
        }
    }
}