using Blog.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.ActionFilters
{
    public class LoggingAtribute : ActionFilterAttribute, IExceptionFilter
    {
        private string controller;
        private string action;
        private string actionType;
        private string parameters;
        private Logging log = new Logging();

        public LoggingAtribute()
        {

        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            action = filterContext.ActionDescriptor.ActionName;
            actionType = filterContext.HttpContext.Request.HttpMethod;
            parameters = string.Empty;
            foreach (var parameter in filterContext.ActionParameters)
            {
                parameters += parameter.Key + "=" + parameter.Value;
            }
            log.Info($"Actiunea {actionType}, {controller}/{action}/{parameters} a inceput.");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            log.Info($"Actiunea {actionType}, {controller}/{action}/{parameters} s-a terminat.");
        }

        public void OnException(ExceptionContext filterContext)
        {
            log.Error("",filterContext.Exception);
        }
    }
}