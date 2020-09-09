using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace L7CrmManager_MVC_
{
    public class RouteConfig
    {
        /*Sa modificati ruta astfel incat sa adaugati si limba in url si la pagini sa faceti ca textul din header sa fie afisat in limba din url
        Sa creati un nou layout si sa il customizati asa cum vreti voi si sa il folositi pe view-urile din Supplier sau din Customer;*/
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { lang = "ro",controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
