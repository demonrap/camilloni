using System.Web;
using System.Web.Optimization;

namespace fc
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

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Vendors/material-kit/js/material.js",
                      "~/Vendors/material-kit/js/material-kit.js",
                      "~/Scripts/jquery.parallax.js",
                      "~/Vendors/owl-carousel/js/owl.carousel.js",
                      "~/Scripts/wow.js",                      
                      "~/Scripts/jquery.counterup.js",
                      "~/Scripts/waypoints.js",
                      "~/Vendors/jasny-bootstrap/js/jasny-bootstrap.js",
                      "~/Vendors/bootstrap-select/js/bootstrap-select.js",
                      "~/Scripts/main.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angularjsen").Include(
                     "~/vendors/angular/angular.js",
                     "~/Vendors/angular/angular-resource.js",
                     "~/Vendors/angular/dirPagination.js",
                     "~/vendors/angular/appStart.js",
                     "~/Vendors/angular/appModules.js",
                     "~/Vendors/angular/appFilters.js",
                     "~/Vendors/angular/appServices.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjsit").Include(
                     "~/vendors/angular/angular.js",
                     "~/vendors/angular/angular-locale_it-it.js",
                     "~/Vendors/angular/angular-resource.js",
                     "~/Vendors/angular/dirPagination.js",
                     "~/vendors/angular/appStart.js",
                     "~/Vendors/angular/appModules.js",
                     "~/Vendors/angular/appFilters.js",
                     "~/Vendors/angular/appServices.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Vendors/jasny-bootstrap/css/jasny-bootstrap.css",
                      "~/Vendors/material-kit/css/material-kit.css",
                      "~/Content/font-awesome.css",
                      "~/Vendors/line-icons/line-icons.css",
                      "~/Content/site.css",
                      "~/Content/animate.css",
                      "~/Vendors/flag-icons/css/flag-icon.css",
                      "~/Vendors/owl-carousel/css/owl.carousel.css",
                      "~/Vendors/owl-carousel/css/owl.theme.css",
                      "~/Vendors/pace/pace.css",
                      "~/Content/responsive.css",
                      "~/Vendors/bootstrap-select/css/bootstrap-select.css"));
        }
    }
}
