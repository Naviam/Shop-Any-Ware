// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The bootstrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC4.App_Start
{
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Email;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Addresses;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.Interfaces;

    using Unity.Mvc3;

    /// <summary>
    /// The bootstrapper.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// The initialise.
        /// </summary>
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// The build unity container.
        /// </summary>
        /// <returns>
        /// The Microsoft.Practices.Unity.IUnityContainer.
        /// </returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ILogger, DummyLogger>();

            // services
            container.RegisterType<IFormsAuthentication, AspFormsAuthentication>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<IEmailService, SmtpService>();
            container.RegisterType<ICookieStorageService, CookieStorageService>();
            container.RegisterType<IAddressService, DeliveryAddressService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IPackagesService, PackagesService>();
            container.RegisterType<IItemsService, ItemsService>();
            container.RegisterType<IRetailersService, RetailersService>();

            // repositories
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IRetailerRepository, RetailerRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IMembershipRepository, MembershipRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IItemsRepository, ItemsRepository>();
            container.RegisterType<IPackageRepository, PackageRepository>();

            return container;
        }
    }
}