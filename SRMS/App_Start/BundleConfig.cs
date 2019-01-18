using System.Web;
using System.Web.Optimization;

namespace SRMS
{
public class BundleConfig
{
// 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
public static void RegisterBundles(BundleCollection bundles)
{
bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
"~/Scripts/jquery-{version}.js"));

bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
"~/Scripts/jquery.validate*"));

// 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
// 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
"~/Scripts/modernizr-*"));

bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
"~/Scripts/bootstrap.js"
));

bundles.Add(new StyleBundle("~/Content/css").Include(
"~/Content/bootstrap.css",
"~/Content/site.css"
));

bundles.Add(new ScriptBundle("~/bundles/HomeJs").Include(
"~/Scripts/js/echarts.min.js",
"~/Scripts/js/home.js",
"~/Scripts/js/sweetalert.min.js",
"~/Scripts/js/toastr.min.js"
));

bundles.Add(new StyleBundle("~/Content/Homecss").Include(
"~/Content/css/Home.css",
"~/Content/css/sweetalert.css",
"~/Content/css/toastr.min.css"
))
;
bundles.Add(new ScriptBundle("~/bundles/deviceworkinginfoJs").Include(
"~/Scripts/js/echarts.min.js",
"~/Scripts/js/deviceworkinginfo.js",
"~/Scripts/js/sweetalert.min.js",
"~/Scripts/js/toastr.min.js"
));

bundles.Add(new StyleBundle("~/Content/deviceworkinginfoCss").Include(
"~/Content/css/general.css",
"~/Content/css/sweetalert.css",
"~/Content/css/toastr.min.css",
"~/Content/css/deviceworkinginfo.css"
))
;
}
}
}
