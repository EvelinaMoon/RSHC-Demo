using System.Web;
using System.Web.Optimization;

namespace RSHCWebApp
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

            bundles.Add(new Bundle("~/Content/rshcthemestyle").Include(
                      "~/RshcCustomTheme/vendor/aos/aos.css",
                      "~/RshcCustomTheme/vendor/bootstrap/js/bootstrap.bundle.min.css",
                      "~/RshcCustomTheme/vendor/bootstrap-icons/bootstrap-icons.css",
                      "~/RshcCustomTheme/vendor/boxicons/css/boxicons.min.css",
                      "~/RshcCustomTheme/vendor/glightbox/css/glightbox.min.css",
                      "~/RshcCustomTheme/vendor/remixicon/remixicon.css",
                      "~/RshcCustomTheme/vendor/swiper/swiper-bundle.min.css",
                      "~/bootstrap-table-master/dist/bootstrap-table.min.css"));

            bundles.Add(new Bundle("~/bundles/rshcthemescripts").Include(
                       "~/RshcCustomTheme/vendor/aos/aos.js",
                       "~/RshcCustomTheme/vendor/bootstrap/js/bootstrap.bundle.min.js",
                       "~/RshcCustomTheme/vendor/glightbox/js/glightbox.min.js",
                       "~/RshcCustomTheme/vendor/isotope-layout/isotope.pkgd.min.js",
                       "~/RshcCustomTheme/vendor/swiper/swiper-bundle.min.js",
                       "~/RshcCustomTheme/vendor/purecounter/purecounter_vanilla.js",
                       "~/RshcCustomTheme/vendor/php-email-form/validate.js",
                       "~/RshcCustomTheme/js/main.js",
                       "~/bootstrap-table-master/tableExport.min.js",
                       "~/bootstrap-table-master/dist/bootstrap-table.min.js",
                       "~/bootstrap-table-master/dist/bootstrap-table-locale-all.min.js",
                       "~/bootstrap-table-master/dist/extensions/export/bootstrap-table-export.min.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
