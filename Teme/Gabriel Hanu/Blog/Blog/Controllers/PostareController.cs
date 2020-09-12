using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    [Authorize]
    public class PostareController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Postare
        public ActionResult Index()
        {
            return View(db.Postares.ToList());
        }

        // GET: Postare/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postare postare = db.Postares.Find(id);
            if (postare == null)
            {
                return HttpNotFound();
            }
            return View(postare);
        }

        // GET: Postare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postare/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titlu,Text,AutorId,DataCreare,UltimulUpdate,Publicata")] Postare postare)
        {
            if (ModelState.IsValid)
            {
                db.Postares.Add(postare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postare);
        }

        // GET: Postare/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postare postare = db.Postares.Find(id);
            if (postare == null)
            {
                return HttpNotFound();
            }
            return View(postare);
        }

        // POST: Postare/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titlu,Text,AutorId,DataCreare,UltimulUpdate,Publicata")] Postare postare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postare);
        }

        // GET: Postare/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postare postare = db.Postares.Find(id);
            if (postare == null)
            {
                return HttpNotFound();
            }
            return View(postare);
        }

        // POST: Postare/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postare postare = db.Postares.Find(id);
            db.Postares.Remove(postare);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
