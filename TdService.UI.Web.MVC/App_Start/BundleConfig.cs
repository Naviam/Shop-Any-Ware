namespace TdService.UI.Web.MVC.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                        "~/Content/less/bootstrap.css",
                        "~/Content/less/responsive.css",
                        "~/Content/styles.css",
                        "~/Content/noty/jquery.noty.css",
                        "~/Content/noty/noty_theme_default.css",
                        "~/Content/noty/noty_theme_twitter.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/json2.js",
                        "~/scripts/linq.min.js",
                        "~/scripts/jquery.validate.min.js",
                        "~/scripts/jquery.validate.unobtrusive.min.js",
                        "~/scripts/ui/jquery-ui-1.8.18.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap/bootstrap-transition.js",
                        "~/Scripts/bootstrap/bootstrap-alert.js",
                        "~/Scripts/bootstrap/bootstrap-modal.js",
                        "~/Scripts/bootstrap/bootstrap-dropdown.js",
                        "~/Scripts/bootstrap/bootstrap-scrollspy.js",
                        "~/Scripts/bootstrap/bootstrap-tab.js",
                        "~/Scripts/bootstrap/bootstrap-tooltip.js",
                        "~/Scripts/bootstrap/bootstrap-popover.js",
                        "~/Scripts/bootstrap/bootstrap-button.js",
                        "~/Scripts/bootstrap/bootstrap-collapse.js",
                        "~/Scripts/bootstrap/bootstrap-carousel.js",
                        "~/Scripts/bootstrap/bootstrap-typeahead.js"));

            bundles.Add(new ScriptBundle("~/bundles/noty").Include(
                        "~/Scripts/noty/jquery.noty.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout-2.1.0.js",
                        "~/Scripts/knockout.mapping-latest.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/knockout-sortable.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/ViewModels/DashboardViewModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
        }
    }
}