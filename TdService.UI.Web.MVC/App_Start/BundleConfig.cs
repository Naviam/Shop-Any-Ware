// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC.App_Start
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Optimization;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        public class AsIsBundleOrderer : IBundleOrderer
        {
            public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
            {
                return files;
            }
        }

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/less/bootstrapcss").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-responsive.css"));

            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                        "~/Content/styles.css",
                        "~/Content/noty/jquery.noty.css",
                        "~/Content/noty/noty_theme_default.css",
                        "~/Content/noty/noty_theme_twitter.css",
                        "~/Scripts/plupload/js/jquery.ui.plupload/css/jquery.ui.plupload.css"));

            var plUploadBundle = new ScriptBundle("~/bundles/plUpload").Include("~/Scripts/plupload/js/plupload.js",
                    "~/Scripts/plupload/js/plupload.html4.js",
                    "~/Scripts/plupload/js/jquery.ui.plupload/jquery.ui.plupload.js");
            plUploadBundle.Orderer = new AsIsBundleOrderer();

            bundles.Add(plUploadBundle);
            var layoutBundle = new ScriptBundle("~/bundles/layout").Include(
                "~/Scripts/jquery-{version}.js",
                "~/scripts/ui/jquery-ui-1.8.18.custom.js",
                "~/Scripts/json2.js",
                "~/Scripts/noty/jquery.noty.js",
                "~/scripts/jquery.validate.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/knockout-2.2.0.js",
                "~/Scripts/knockout.mapping-latest.js",
                "~/Scripts/knockout.validation.js",
                "~/Scripts/knockout-sortable.js",
                "~/Scripts/jquery.simpleplaceholder.js",
                "~/Scripts/Common.js",
                "~/Scripts/Tools/UspsService.js");
            layoutBundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(layoutBundle);

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/ViewModels/MemberDashboard/DashboardViewModel.js",
                        "~/Scripts/ViewModels/MemberDashboard/Item.js",
                        "~/Scripts/ViewModels/MemberDashboard/Order.js",
                        "~/Scripts/ViewModels/MemberDashboard/Package.js",
                        "~/Scripts/ViewModels/MemberDashboard/Transaction.js"));

            bundles.Add(new ScriptBundle("~/bundles/addresses").Include(
                          "~/Scripts/ViewModels/AddressViewModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/ViewModels/SignInViewModel.js",
                        "~/Scripts/ViewModels/SignUpViewModel.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminDashboard").Include(
                        "~/Scripts/ViewModels/AdminDashboardViewModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
        }
    }
}