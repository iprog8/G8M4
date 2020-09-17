using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Blog.Controllers
{
    public class ArticolController : Controller
    {
        // GET: Articol
        public ActionResult Index(int page = 1)
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
                    Text = p.Text,
                    ListaComentarii = p.Comentarius
                    .Where(s => s.Aprobat)
                    .Select(c => new ComentariuViewModel { 
                        Id = c.Id,
                        DataCreare = c.DataCreare,
                        Aprobat = c.Aprobat,
                        Edited = c.Edited,
                        Nume = c.Nume,
                        Text = c.Text,
                        Titlu = c.Titlu
                    }).ToList(),
                    ListaPoze = p.Pozas
                }))
                .FirstOrDefault(p => p.Id == id);
            return View(model);
        }
    }
}