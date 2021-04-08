using System.Web;
using System.Web.Optimization;

namespace PersonalSiteMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Content/assets/plugins/jquery-3.4.1.min.js",
                        "~/Content/assets/plugins/popper.min.js",
                        "~/Content/assets/plugins/bootstrap/js/bootstrap.min.js",
                        "~/Content/assets/plugins/back-to-top.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Content/assets/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Content/assets/plugins/jquery-validation/jquery.validate.min.js",
                        "~/Content/assets/js/form.js"));
        }
    }
}
