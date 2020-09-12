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
    public class PozaController : Controller
    {   
        private BlogEntities db = new BlogEntities();

        // GET: Poza
        public ActionResult Index()
        {
            var pozas = db.Pozas.Include(p => p.Postare);
            return View(pozas.ToList());
        }

        // GET: Poza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poza poza = db.Pozas.Find(id);
            if (poza == null)
            {
                return HttpNotFound();
            }
            return View(poza);
        }

        // GET: Poza/Create
        public ActionResult Create()
        {
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu");
            return View();
        }

        // POST: Poza/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostareId,CalePoza")] Poza poza)
        {
            if (ModelState.IsValid)
            {
                db.Pozas.Add(poza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", poza.PostareId);
            return View(poza);
        }

        // GET: Poza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poza poza = db.Pozas.Find(id);
            if (poza == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", poza.PostareId);
            return View(poza);
        }

        // POST: Poza/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostareId,CalePoza")] Poza poza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", poza.PostareId);
            return View(poza);
        }

        // GET: Poza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poza poza = db.Pozas.Find(id);
            if (poza == null)
            {
                return HttpNotFound();
            }
            return View(poza);
        }

        // POST: Poza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poza poza = db.Pozas.Find(id);
            db.Pozas.Remove(poza);
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
