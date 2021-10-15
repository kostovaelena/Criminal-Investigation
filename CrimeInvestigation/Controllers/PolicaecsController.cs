using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrimeInvestigation.Models;

namespace CrimeInvestigation.Controllers
{
    public class PolicaecsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Policaecs
        [Authorize(Roles = "Policaec")]

        public ActionResult Index()
        {
            return View(db.Policaecs.ToList());
        }



        // GET: Policaecs/Details/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policaec policaec = db.Policaecs.Find(id);
            if (policaec == null)
            {
                return HttpNotFound();
            }
            var i = db.Policaecs.Find(id);
            ViewBag.Ime = i.Ime;
            ViewBag.Prezime = i.Prezime;
            ViewBag.ID = i.policaecId;
            return View(policaec);
        }

        // GET: Policaecs/Create
        [Authorize(Roles = "Policaec")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Policaecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "policaecId,Ime,Prezime,iskustvo,urlslika")] Policaec policaec)
        {
            if (ModelState.IsValid)
            {
                db.Policaecs.Add(policaec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policaec);
        }

        // GET: Policaecs/Edit/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policaec policaec = db.Policaecs.Find(id);
            if (policaec == null)
            {
                return HttpNotFound();
            }
            return View(policaec);
        }

        // POST: Policaecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ime,policaecId,Prezime,iskustvo,urlslika")] Policaec policaec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policaec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policaec);
        }

        // GET: Policaecs/Delete/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policaec policaec = db.Policaecs.Find(id);
            if (policaec == null)
            {
                return HttpNotFound();
            }
            var i = db.Policaecs.Find(id);
            ViewBag.Ime = i.Ime;
            ViewBag.Prezime = i.Prezime;
            ViewBag.ID = i.policaecId;
            return View(policaec);
        }

        // POST: Policaecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Policaec policaec = db.Policaecs.Find(id);
            db.Policaecs.Remove(policaec);
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
