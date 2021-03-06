﻿using System.Web.Optimization;

namespace AuthAuthDemo.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                      "~/Scripts/gridmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                        "~/Scripts/register.js"));

            bundles.Add(new StyleBundle("~/bundles/Styles/site").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/Styles/gridmvc").Include(
                      "~/Content/Gridmvc.css"));

            bundles.Add(new StyleBundle("~/bundles/Styles/register").Include(
                      "~/Content/register.css"));
        }
    }
}
