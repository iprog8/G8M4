using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace Blog.Controllers
{
    public class ArticolController : Controller
    {
        // GET: Articol
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            BlogEntities db = new BlogEntities();
            ArticolViewModel model = db.Postares.Include(a => a.Pozas)
                .Include(p => p.Comentarius)
                .Select((p => new ArticolViewModel
                {
                    Id = p.Id,
                    Titlu = p.Titlu,
                    DataCreare = p.DataCreare,
                    Text   = p.Text,
                    ListaComentarii = p.Comentarius,
                    ListaPoze = p.Pozas
                }))
                .FirstOrDefault(p => p.Id == id);
            return View(model);
        }
    }

}