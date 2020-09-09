using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrmManagerMvc.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult _LanguagePartial()
        {
            LanguageViewModel model = new LanguageViewModel();
            model.CurrentLanguage = (string)this.RouteData.Values["language"];
            model.CurrentTheme = (string)this.RouteData.Values["theme"];
            model.GetValues(HttpContext.Request.RawUrl);
            return PartialView(model);
        }
    }
}