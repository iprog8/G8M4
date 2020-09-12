using Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Blog.Controllers
{
    public class ImagineController : Controller
    {
        // GET: Imagine
        public ActionResult Index(int page = 1)
        {
            var caleImagini = Server.MapPath(Imagine.CaleImagini);
            if (!Directory.Exists(caleImagini))
            {
                Directory.CreateDirectory(caleImagini);
            }
            var imagini = Directory.GetFiles(caleImagini);
            ICollection<Imagine> model = new List<Imagine>();
            foreach (var caleImagine in imagini)
            {
                if(caleImagine.Contains(".png") || caleImagine.Contains(".jpg") || caleImagine.Contains(".jpeg"))
                {
                    var numeFisier = Path.GetFileName(caleImagine);
                    var caleImagineServer = Path.Combine(Imagine.CaleImagini, numeFisier);
                    model.Add(new Imagine { Cale = caleImagineServer });
                }
            }
            return View(model);
        }

        // GET: Imagine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagine/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath(Imagine.CaleImagini), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Incarcare reusita!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "Incarcare esuata!!";
                return View();
            }
        }

        // GET: Imagine/Delete/5
        public ActionResult Delete(string cale)
        {
            string caleFizica = Server.MapPath(cale);
            if(System.IO.File.Exists(caleFizica))
            {
                System.IO.File.Delete(caleFizica);
            }
            return RedirectToAction("Index");
        }

    }
}
