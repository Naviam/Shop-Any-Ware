// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC4.App_Start
{
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-responsive.min.css",
                        "~/Content/styles.css",
                        "~/Content/noty/jquery.noty.css",
                        "~/Content/noty/noty_theme_default.css",
                        "~/Content/noty/noty_theme_twitter.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/json2.min.js",
                        "~/scripts/jquery.validate.min.js",
                        "~/scripts/jquery.validate.unobtrusive.min.js",
                        "~/scripts/jquery-ui-1.8.23.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/noty").Include(
                        "~/Scripts/noty/jquery.noty.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-2.1.0.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/ViewModels/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/ViewModels/DashboardViewModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/ViewModels/SignInViewModel.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}