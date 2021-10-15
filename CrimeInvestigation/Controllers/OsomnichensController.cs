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
    public class OsomnichensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Osomnichens
        [Authorize(Roles = "Policaec")]

        public ActionResult Index()
        {
            return View(db.Osomnichens.ToList());
        }

        // GET: Osomnichens/Details/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osomnichen osomnichen = db.Osomnichens.Find(id);
            if (osomnichen == null)
            {
                return HttpNotFound();
            }
            return View(osomnichen);
        }

        // GET: Osomnichens/Create
        [Authorize(Roles = "Policaec")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Osomnichens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Godini,opisOsomnichen,Slika,tipObvinenie")] Osomnichen osomnichen)
        {
            if (ModelState.IsValid)
            {
                db.Osomnichens.Add(osomnichen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osomnichen);
        }

        // GET: Osomnichens/Edit/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osomnichen osomnichen = db.Osomnichens.Find(id);
            if (osomnichen == null)
            {
                return HttpNotFound();
            }
            return View(osomnichen);
        }

        // POST: Osomnichens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Godini,opisOsomnichen,Slika,tipObvinenie")] Osomnichen osomnichen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osomnichen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osomnichen);
        }

        // GET: Osomnichens/Delete/5
        [Authorize(Roles = "Policaec")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osomnichen osomnichen = db.Osomnichens.Find(id);
            if (osomnichen == null)
            {
                return HttpNotFound();
            }
            return View(osomnichen);
        }

        // POST: Osomnichens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Osomnichen osomnichen = db.Osomnichens.Find(id);
            db.Osomnichens.Remove(osomnichen);
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
