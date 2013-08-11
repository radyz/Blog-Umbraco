using System;
using System.Web;
using System.Web.Optimization;

using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;

namespace Radyz.Web
{
    public class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.UseCdn = true;

            var nullBuilder = new NullBuilder();
            var nullOrderer = new NullOrderer();

            //Jquery - TODO: It would be awesome to add a build step to get only what we need from jquery
            var jqueryBundle = new CustomScriptBundle("~/bundles/jquery", "//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js");
            jqueryBundle.Include("~/scripts/vendor/jquery-{version}.js");
            jqueryBundle.CdnFallbackExpression = "window.jQuery";
            jqueryBundle.Orderer = nullOrderer;
            bundleCollection.Add(jqueryBundle);

            //Modernizr - TODO: same as jquery build step
            var modernizrBundle = new CustomScriptBundle("~/bundles/modernizr");
            modernizrBundle.Include("~/scripts/vendor/modernizr-2.6.2.js");
            modernizrBundle.Orderer = nullOrderer;
            bundleCollection.Add(modernizrBundle);

            //Remaining js
            var mainjsBundle = new CustomScriptBundle("~/bundles/site-js");
            mainjsBundle.Include("~/scripts/main.js", "~/scripts/plugins.js");
            mainjsBundle.Orderer = nullOrderer;
            bundleCollection.Add(mainjsBundle);

            //Less 
            var mainlessBundle = new CustomStyleBundle("~/bundles/site-less");
            mainlessBundle.Include("~/less/main.less");
            mainlessBundle.Orderer = nullOrderer;
            bundleCollection.Add(mainlessBundle);

            //Css - Place plugin's css files
            var maincssBundle = new CustomStyleBundle("~/bundles/site-css");
            maincssBundle.IncludeDirectory("~/css", "*.css");
            maincssBundle.Orderer = nullOrderer;
            bundleCollection.Add(maincssBundle);
        }
    }
}