using System.Web;
using System.Web.Optimization;

namespace GerenciarEquipe.Painel
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ModalAdminJS")
                     .Include("~/Scripts/vendor.js")
                     .Include("~/Scripts/app.js")
                     .Include("~/Scripts/image.js")
                     .Include("~/Scripts/modal.js")
                     .Include("~/Scripts/datatables.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", 
                      "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminApp").Include(
                    "~/Content/vendor.css",
                    "~/Content/app.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppBlue").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-blue.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppGreen").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-green.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppOrange").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-orange.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppPurple").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-purple.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppRed").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-red.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/ModalAdminAppSeaGreen").Include(
                    "~/Content/vendor.css",
                    "~/Content/app-seagreen.css",
                    "~/Content/site.css",
                    "~/Content/datatables.min.css"));
        }
    }
}
