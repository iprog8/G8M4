﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrmManagerMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{theme}/{language}/{controller}/{action}/{id}",
                defaults: new {theme = "theme-white", language = "en", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
