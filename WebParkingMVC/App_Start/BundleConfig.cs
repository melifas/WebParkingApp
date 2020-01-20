using System.Web;
using System.Web.Optimization;

namespace WebParkingMVC
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region Template

            bundles.Add(new ScriptBundle("~/template/js").Include(
                       "~/Scripts/jquery.js",
                       "~/Scripts/jquery.easing.1.3.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/jcarousel/jquery.jcarousel.min.js",
                       "~/Scripts/jquery.fancybox.pack.js",
                       "~/Scripts/jquery.fancybox-media.js",
                       "~/Scripts/google-code-prettify/prettify.js",
                       "~/Scripts/portfolio/jquery.quicksand.js",
                       "~/Scripts/portfolio/setting.js",
                       "~/Scripts/jquery.flexslider.js",
                       "~/Scripts/jquery.nivo.slider.js",
                       "~/Scripts/modernizr.custom.js",
                       "~/Scripts/jquery.ba-cond.min.js",
                       "~/Scripts/jquery.slitslider.js",
                       "~/Scripts/animate.js",
                       "~/ Scripts /custom.js"
                       ));

            bundles.Add(new StyleBundle("~/template/css").Include(
                    "~/Content/css/bootstrap.css",
                    "~/Content/css/bootstrap-responsive.css",
                    "~/Content/css/fancybox/jquery.fancybox.css",
                    "~/Content/css/jcarousel.css",
                    "~/Content/css/flexslider.css",
                    "~/Content/css/style.css",
                    "~/Content/skins/default.css"
                    ));

            bundles.Add(new StyleBundle("~/template/ico").Include(
                   "~/ico/apple-touch-icon-144-precomposed.png",
                   "~/ico/apple-touch-icon-114-precomposed.png",
                   "~/ico/apple-touch-icon-72-precomposed.png",
                   "~/ico/apple-touch-icon-57-precomposed.png",
                   "~/ico/favicon.png"
                   ));

            #endregion
        }
    }
}
