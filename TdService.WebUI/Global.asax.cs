// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the MvcApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using TdService.Repository.MsSql;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Global Asax class configures web application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Register global filters such as error handlers
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }); // Parameter defaults
        }

        /// <summary>
        /// Application start even handler
        /// </summary>
        protected void Application_Start()
        {
            DatabaseInitializer.InitializeShopAnyWare();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            // 1. Create a new Simple Injector container
            // var container = new Container();

            // 2. Configure the container (register)
            // container.RegisterSingle<IOrderRepository, OrderRepository>();

            // See below for more configuration examples

            // 3. Optionally verify the container's configuration.
            // container.Verify();

            // 4. Store the container for use by Page classes.
            // Global.Container = container;
        }
    }
}