// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Combres.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Combres type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

[assembly: WebActivator.PreApplicationStartMethod(typeof(TdService.UI.Web.MVC.App_Start.Combres), "PreStart")]

namespace TdService.UI.Web.MVC.App_Start
{
    using System.Web.Routing;

    using global::Combres;

    /// <summary>
    /// Combres helper class.
    /// </summary>
    public static class Combres
    {
        /// <summary>
        /// Pre start combres method.
        /// </summary>
        public static void PreStart()
        {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}