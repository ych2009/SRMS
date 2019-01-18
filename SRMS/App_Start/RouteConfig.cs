using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SRMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "manipulator",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "manipulatorinfoSets", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Tips",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Tips", id = UrlParameter.Optional }
            );
        }
    }
}
