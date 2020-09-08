using CrmManagerMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace CrmManagerMvc.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult _LanguagePartial()
        {
            LanguageViewModel model = new LanguageViewModel();
            model.GetValues(HttpContext.Request.RawUrl, this.RouteData);
            return PartialView(model);
        }
    }
}