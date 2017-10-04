﻿using System.Web;
using System.Web.Optimization;

namespace QandA
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-ui-router.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-sanitize.js",
                      "~/Scripts/angular-growl.min.js",
                      "~/Scripts/angular-cookies.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-file-upload.min.js",
                      "~/Scripts/tinymce/tinymce.js",
                      "~/Scripts/ui-tinymce.js",
                      "~/Ng/Controllers/app.js",
                      "~/Ng/Controllers/Qna-*",
                      "~/Ng/Service/Qna-*"
                ));
        }
    }
}