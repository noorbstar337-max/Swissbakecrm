Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254726
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New StyleBundle("~/Admin/css/Admin_Master_css").Include(
                         "~/Admin/css/bootstrap.min.css",
                         "~/Admin/css/plugins.css",
                         "~/Admin/css/main.css",
                         "~/Admin/css/themes.css"))
        bundles.Add(New ScriptBundle("~/Admin/css/Admin_Master_js").Include(
                    "~/Admin/js/vendor/modernizr-2.7.1-respond-1.4.2.min.js",
                    "~/Admin/js/jquery.min.js",
                        "~/Admin/js/vendor/bootstrap.min.js",
                        "~/Admin/js/plugins.js",
                        "~/Admin/js/app.js",
                        "~/Admin/js/pages/uiProgress.js"))
        bundles.Add(New ScriptBundle("~/Admin/css/Ckeditor_js").Include(
                    "~/Admin/js/ckeditor/ckeditor.js"
                   ))
        bundles.Add(New ScriptBundle("~/JS/Site_Master_js").Include(
                  "~/Scripts/js/jquery.min.js",
                  "~/Scripts/js/waypoints.min.js",
                      "~/rs-plugin/js/jquery.themepunch.tools.min.js",
                      "~/rs-plugin/js/jquery.themepunch.revolution.min.js",
                      "~/Scripts/js/jquery.animateNumber.min.js",
                      "~/Scripts/js/slick.min.js",
                      "~/Scripts/js/jquery.easypiechart.min.js",
                      "~/Scripts/js/jquery.prettyPhoto.js",
                      "~/Scripts/js/jquery.sharrre.min.js",
                      "~/Scripts/js/jquery.elevateZoom-3.0.8.min.js",
                      "~/Scripts/js/jquery.placeholder.js",
                      "~/Scripts/js/script.js"))
    End Sub
End Class
