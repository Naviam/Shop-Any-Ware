// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleInjectorInitializer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This class is for Simple Injector Dependency Injection initialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

[assembly: WebActivator.PreApplicationStartMethod(typeof(TdService.UI.Web.MVC.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace TdService.UI.Web.MVC.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Email;
    using TdService.Model.Addresses;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Repository.MsSql.Repositories;
    using TdService.Services.Implementations;
    using TdService.Services.Interfaces;

    /// <summary>
    /// This class is for Simple Injector Dependency Injection initialization.
    /// </summary>
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcAttributeFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        /// <summary>
        /// Initialize containers here.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        private static void InitializeContainer(Container container)
        {
            // services
            container.Register<IFormsAuthentication, AspFormsAuthentication>();
            container.Register<IMembershipService, MembershipService>();
            container.Register<IEmailService, SmtpService>();
            container.Register<ICookieStorageService, CookieStorageService>();
            container.Register<IAddressService, DeliveryAddressService>();
            container.Register<IOrderService, OrderService>();
            container.Register<IPackagesService, PackagesService>();
            container.Register<IItemsService, ItemsService>();
            container.Register<IRetailersService, RetailersService>();

            // repositories
            container.Register<IOrderRepository, OrderRepository>();
            container.Register<IRetailerRepository, RetailerRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IRoleRepository, RoleRepository>();
            container.Register<IProfileRepository, ProfileRepository>();
            container.Register<IMembershipRepository, MembershipRepository>();
            container.Register<IAddressRepository, AddressRepository>();
            container.Register<IItemsRepository, ItemsRepository>();
            container.Register<IPackageRepository, PackageRepository>();

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();
        }
    }
}