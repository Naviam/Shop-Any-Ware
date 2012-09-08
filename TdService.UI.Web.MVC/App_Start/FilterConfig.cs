namespace TdService.UI.Web.MVC.App_Start
{
    using System.Web.Mvc;

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