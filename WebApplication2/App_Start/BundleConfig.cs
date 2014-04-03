using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;

namespace WebApplication2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            //Read configured resposive design framework js from web config and bundle
            string responsiveDesignJs = WebConfigurationManager.AppSettings["RDScript"].ToString();
            bundles.Add(new ScriptBundle("~/bundles/responsivejs").Include(
                    responsiveDesignJs,
                    "~/Scripts/respond.js"));            

            //bundles.Add(new ScriptBundle("~/bundles/responsivejs").Include(
            //          "~/Scripts/bootstrap/bootstrap.js",
            //          "~/Scripts/bootstrap/respond.js"));

            //Read configured bootstrap theme name from web config and bundle
            string responsiveDesignTheme = WebConfigurationManager.AppSettings["RDTheme"].ToString();

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      responsiveDesignTheme,
                      "~/Content/site.css"));
            

            //Let's deal with less and its transform
            var commonStylesBundle = new Bundle("~/Content/less");
            commonStylesBundle.Builder = new NullBuilder();
            commonStylesBundle.Transforms.Add(new CssTransformer());
            commonStylesBundle.Orderer = new NullOrderer();
            commonStylesBundle.Include("~/Content/less/*.less");
            bundles.Add(commonStylesBundle);
        }
    }
}
