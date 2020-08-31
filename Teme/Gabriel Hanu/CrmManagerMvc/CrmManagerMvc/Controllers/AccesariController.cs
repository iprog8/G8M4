using CrmManagerMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CrmManagerMvc.Controllers
{
    public class AccesariController : Controller
    {
        // GET: Accesari
        public ActionResult _NumarAccesari(string numePagina, string id)
        {
            numePagina += id;
            NumarAccesari model = new NumarAccesari();
            model.Accesari = UpdatePageAcces(numePagina);
            return PartialView(model);
        }
        private string UpdatePageAcces(string pageName)
        {
            CRMEntities db = new CRMEntities();
            var page = db.Pages.FirstOrDefault(p => p.NumePagina == pageName);
            if (page == null)
            {
                Models.Page tempPage = new Models.Page();
                tempPage.NumePagina = pageName;
                tempPage.NumarAccesari = 0;
                db.Pages.Add(tempPage);
                page = tempPage;
            }
            page.NumarAccesari++;
            db.SaveChanges();
            return page.NumarAccesari.ToString();
        }
    }
}