using System;
using System.Web;
using System.Web.Optimization;
using Radyz.Web.Optimization;

namespace Radyz.Web
{
    public class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.UseCdn = true;

            //Jquery - TODO: It would be awesome to add a build step to get only what we need from jquery
            var jqueryCdn = "//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js";
            bundleCollection.Add(new Bundle("~/bundles/jquery", jqueryCdn, new JsMinify())
                .Include("~/scripts/vendor/jquery-{version}.js"));

            //Modernizr - TODO: same as jquery build step
            bundleCollection.Add(new Bundle("~/bundles/modernizr", new JsMinify())
                .Include("~/scripts/vendor/modernizr-2.6.2.js"));

            //Remaining js
            bundleCollection.Add(new Bundle("~/bundles/site-js", new JsMinify())
                .Include("~/scripts/main.js", "~/scripts/plugins.js"));

            //Less - TODO: dotless is looking at its last days on the web, need to find a new parser similar to it
            bundleCollection.Add(new Bundle("~/bundles/site-less", new LessTransform(), new CssMinify())
                .Include("~/less/main.less"));
        }
    }
}