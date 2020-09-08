using FirstMvcApp.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMvcApp.ActionFilters
{
    public class LogExceptionFilter : FilterAttribute, IExceptionFilter
    {
        string controller = string.Empty;
        string action = string.Empty;
        Logging log = new Logging();
        string actionType = string.Empty;
        string parameters = string.Empty;

        public void OnException(ExceptionContext filterContext)
        {
            controller = filterContext.RouteData.Values["controller"].ToString();
            action = filterContext.RouteData.Values["action"].ToString();
            actionType = filterContext.HttpContext.Request.HttpMethod;
            log.Error($"Erorr on [{actionType}] /{controller}/{action}", filterContext.Exception);
            
            filterContext.Result =
                new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Error"
                }));
        }
    }
}