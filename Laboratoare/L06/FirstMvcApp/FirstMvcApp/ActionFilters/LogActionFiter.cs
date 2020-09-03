using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using FirstMvcApp.Features;

namespace FirstMvcApp.ActionFilters
{
    public class LogActionFiter: ActionFilterAttribute
    {
        DateTime timeStart;
        string controller = string.Empty;
        string action = string.Empty;
        Logging log = new Logging();
        string actionType = string.Empty;
        string parameters = string.Empty;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            action = filterContext.ActionDescriptor.ActionName;
            actionType = filterContext.HttpContext.Request.HttpMethod; 
            parameters = string.Empty;
            foreach (var item in filterContext.ActionParameters)
            {
                parameters += "&" + item.Key + "=" + item.Value;
            }
            timeStart = DateTime.Now;
            log.Info($"Action {actionType} - {controller}/{action}/{parameters} starts");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            TimeSpan timeSpan = DateTime.Now - timeStart;
            log.Info($"Action {controller}/{action} end after {timeSpan.TotalMilliseconds} ms");
        }
    }
}