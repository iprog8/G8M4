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
        public ActionResult Index(int pagina = 1)
        {
            BlogEntities db = new BlogEntities();
            ArticolIndexViewModel model = new ArticolIndexViewModel();
            model.ListaArticole = db.Postares.Where(a => a.Publicata).Include(p => p.Pozas)
                    .OrderByDescending(p => p.DataCreare)
                    .Skip(model.Paginare.ItemsPerPage * (pagina - 1))
                    .Take(model.Paginare.ItemsPerPage)
                    .Select(p => new ArticolViewModel
                    {
                        Id = p.Id,
                        Titlu = p.Titlu,
                        DataCreare = p.DataCreare,
                        Text = p.Text.Length > 250 ? p.Text.Remove(250) : p.Text,
                        ListaPoze = p.Pozas.OrderByDescending(l => l.CalePoza).Take(1).ToList()
                    }).ToList();
                return View(model);
        }
        public ActionResult Details(int id)
        {
            BlogEntities db = new BlogEntities();
            ArticolViewModel model = db.Postares.OrderByDescending(p => p.DataCreare).Include(a => a.Pozas)
                .Include(p => p.Comentarius)
                .Select((p => new ArticolViewModel
                {
                    Id = p.Id,
                    Titlu = p.Titlu,
                    DataCreare = p.DataCreare,
                    Text = p.Text,
                    ListaComentarii = p.Comentarius.Where(a => a.Aprobat).OrderByDescending(s => s.DataCreare).ToList(),
                    ListaPoze = p.Pozas
                }))
                .FirstOrDefault(p => p.Id == id);
            model.LoggedUser = User.Identity.Name;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _AdaugaComentariu(Comentariu comentariu)
        {
            BlogEntities db = new BlogEntities();
            if (ModelState.IsValid)
            {
                comentariu.DataCreare = DateTime.Now;
                db.Comentarius.Add(comentariu);
                db.SaveChanges();
                return RedirectToAction("Details", new { Id = comentariu.PostareId});
            }
            return View(comentariu);
        }
    }
}