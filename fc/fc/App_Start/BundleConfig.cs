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
                       "~/Scripts/sweetalert2.js",
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
            
            #region admin
            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include(
                       "~/Scripts/admin/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/jqueryval").Include(
                        "~/Scripts/admin/jquery.validate*"));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/admin/modernizr").Include(
                        "~/Scripts/admin/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/admin/theme").Include(
                      "~/Scripts/admin/bootstrap.js",
                      "~/Scripts/admin/theme/material.js",
                      "~/Scripts/admin/theme/chartist.js",
                      "~/Scripts/admin/theme/arrive.js",
                      "~/Scripts/admin/theme/perfect-scrollbar.jquery.js",
                      "~/Scripts/admin/theme/bootstrap-notify.js",
                      "~/Scripts/admin/theme/sweetalert2.js",
                      "~/Scripts/admin/theme/jasny-bootstrap.js",
                      "~/Scripts/admin/theme/jquery.tagsinput.js",
                      "~/Scripts/admin/theme/jquery.select-bootstrap.js",
                      "~/Scripts/admin/theme/material-dashboard.js",
                      "~/Scripts/admin/theme/back-to-top.js",
                      "~/Scripts/admin/theme/typeahead.js",
                      "~/Vendors/admin/bootstrap-select/js/bootstrap-select.js",
                      "~/Vendors/admin/bootstrap-select/js/ajax-bootstrap-select.js",
                      "~/Vendors/admin/bootstrap-select/js/i18n/defaults-it_IT.js",
                      "~/Scripts/admin/respond.js",
                      "~/Scripts/config.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/angularjs").Include(
                       "~/Vendors/angular/angular.js",
                       "~/Vendors/angular/angular-sanitize.js",
                       "~/Vendors/angular/angular-animate.js",
                       "~/Vendors/angular/angular-touch.js",
                       "~/Vendors/angular/angular-locale_it-it.js",
                       "~/Vendors/angular/angular-resource.js",
                       "~/Vendors/angular/dirPagination.js",
                       "~/Vendors/angular/appStart.js",
                       "~/Vendors/angular/appModules.js",
                       "~/Vendors/angular/appFilters.js",
                       "~/Vendors/angular/appServices.js"));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/Content/admin/bootstrap.css",
                      "~/Content/admin/material-dashboard.css",
                      "~/Content/admin/bootstrap-datepicker.css",
                      "~/Vendors/admin/bootstrap-select/css/bootstrap-select.css",
                      "~/Vendors/admin/bootstrap-select/css/ajax-bootstrap-select.css",
                      "~/Content/admin/back-to-top.css"));
            #endregion
        }
    }
}
