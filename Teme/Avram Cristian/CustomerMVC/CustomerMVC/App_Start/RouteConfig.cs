using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomerMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Multilanguage",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = "ro", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

          

            routes.MapRoute(
                name: "Multilanguage2",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = "en", controller = "Customers", action = "Index2", id = UrlParameter.Optional }
            );
        }
    }
}
