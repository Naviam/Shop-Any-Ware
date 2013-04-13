// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Naviam">
//   Vitali Hatalski. 2012
// </copyright>
// <summary>
//   The filter config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC.App_Start
{
    using System.Web.Mvc;

    /// <summary>
    /// The filter config.
    /// </summary>
    public class FilterConfig
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
    }
}