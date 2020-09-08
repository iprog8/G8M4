using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser;
using System.Web.Routing;

namespace CrmManagerMvc.ActionFilters
{
    public class UserAuthorize: AuthorizeAttribute
    {
        private string Controller { get; set; }
        private string Action { get; set; }
        private string Id { get; set; }
        private string UrlForReturn { get; set; }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            GetUrlValues(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login",
                    ReturnUrl = UrlForReturn
                }));
               // base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = Controller, action = Action }));
            }
        }
        private void GetUrlValues(AuthorizationContext authorizationContext)
        {
            var routeData = authorizationContext.RequestContext.RouteData;
            Controller = (string)routeData.Values["controller"];
            Action = (string)routeData.Values["action"];
            Id = (string)routeData.Values["id"];
            UrlForReturn = $"/{routeData.Values["theme"]}/{routeData.Values["language"]}/{Controller}/{Action}";
            if (Id != null) UrlForReturn += $"/{Id}";
        }
    }
}