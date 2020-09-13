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
    public class ComentariuController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Comentariu
        public ActionResult Index(bool neaprobate = false)
        {
            var query = db.Comentarius.Include(c => c.Postare);
            if (neaprobate)
            {
                query = query.Where(c => !c.Aprobat);
            }
            query = query.OrderByDescending(c => c.DataCreare);
            return View(query.ToList());
        }

        public ActionResult _ComentariiLink()
        {
            var model = db.Comentarius.Where(c => !c.Aprobat).Count();
            return PartialView(model);
        }

        // GET: Comentariu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentariu comentariu = db.Comentarius.Find(id);
            if (comentariu == null)
            {
                return HttpNotFound();
            }
            return View(comentariu);
        }

        // GET: Comentariu/Create
        public ActionResult Create()
        {
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu");
            return View();
        }

        // POST: Comentariu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PostareId,Titlu,Text,ComentatorId,Nume,Email,SiteWeb,ParentId,DataCreare,Edited,Aprobat")] Comentariu comentariu)
        {
            if (ModelState.IsValid)
            {
                db.Comentarius.Add(comentariu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", comentariu.PostareId);
            return View(comentariu);
        }

        // GET: Comentariu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentariu comentariu = db.Comentarius.Find(id);
            if (comentariu == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", comentariu.PostareId);
            return View(comentariu);
        }

        // POST: Comentariu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostareId,Titlu,Text,ComentatorId,Nume,Email,SiteWeb,ParentId,DataCreare,Edited,Aprobat")] Comentariu comentariu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentariu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostareId = new SelectList(db.Postares, "Id", "Titlu", comentariu.PostareId);
            return View(comentariu);
        }

        // GET: Comentariu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentariu comentariu = db.Comentarius.Find(id);
            if (comentariu == null)
            {
                return HttpNotFound();
            }
            return View(comentariu);
        }

        // POST: Comentariu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentariu comentariu = db.Comentarius.Find(id);
            db.Comentarius.Remove(comentariu);
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
        public ActionResult Aproba(int comentariuID) {

            Comentariu comentariu = db.Comentarius.Find(comentariuID);
            comentariu.Aprobat = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
