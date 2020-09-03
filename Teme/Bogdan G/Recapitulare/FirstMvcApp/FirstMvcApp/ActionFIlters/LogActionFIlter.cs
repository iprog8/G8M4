using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace FirstMvcApp.ActionFilters
{
    public class LogActionFiter : ActionFilterAttribute
    {
        DateTime timeStart;
        string controller = string.Empty;
        string action = string.Empty;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            controller = filterContext.RouteData.Values["controller"].ToString();
            action = filterContext.RouteData.Values["action"].ToString();
            timeStart = DateTime.Now;
            Debug.WriteLine($"Action {controller}/{action} starts at {timeStart.ToLongTimeString()}");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            TimeSpan timeSpan = DateTime.Now - timeStart;
            Debug.WriteLine($"Action {controller}/{action} duration = {timeSpan.TotalMilliseconds}");
        }
    }
}