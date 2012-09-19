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
    using System.Web.Optimization;
    using System.Web.Routing;

    using TdService.Repository.MsSql;
    using TdService.UI.Web.MVC.App_Start;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Global Asax class configures web application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application start even handler
        /// </summary>
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();

            DatabaseInitializer.InitializeShopAnyWare();

            // AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialise();
        }
    }
}