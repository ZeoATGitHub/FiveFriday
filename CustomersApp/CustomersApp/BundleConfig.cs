﻿using System.Web;
using System.Web.Optimization;

namespace CustomersApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.js",
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/Content/").Include(
                        "~/Content/jquery-ui.min.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-3.4.2.js",
              "~/Scripts/CustomersAppJS.js"));

            bundles.Add(new ScriptBundle("~/bundles/velocity").Include(
                "~/Scripts/velocity.min.js",
                "~/Scripts/velocity.ui.js"));

        

        }
    }
}


 

   
    
    