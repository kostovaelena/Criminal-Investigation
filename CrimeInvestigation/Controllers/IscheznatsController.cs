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
    public class IscheznatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ischeznats
        public ActionResult Index()
        {
            return View(db.Ischeznats.ToList());
        }

        // GET: Ischeznats/Details/5
        public ActionResult Details(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ischeznat ischeznat = db.Ischeznats.Find(id);
            if (ischeznat == null)
            {
                return HttpNotFound();
            }
            var i = db.Ischeznats.Find(id);
            ViewBag.Ime = i.Ime;
            ViewBag.Prezime = i.Prezime;
            return View(ischeznat);
           
        }

        // GET: Ischeznats/Create
        [Authorize(Roles = "Korisnik")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ischeznats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Godini,Grad,Adresa,Datum,Vreme,Mesto,Izgled,Slika")] Ischeznat ischeznat)
        {
            if (ModelState.IsValid)
            {
                db.Ischeznats.Add(ischeznat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ischeznat);
        }

        // GET: Ischeznats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ischeznat ischeznat = db.Ischeznats.Find(id);
            if (ischeznat == null)
            {
                return HttpNotFound();
            }
            var i = db.Ischeznats.Find(id);
            ViewBag.Ime = i.Ime;
            ViewBag.Prezime = i.Prezime;
            return View(ischeznat);
        }

        // POST: Ischeznats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Godini,Grad,Adresa,Datum,Vreme,Mesto,Izgled,Slika")] Ischeznat ischeznat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ischeznat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ischeznat);
        }

        // GET: Ischeznats/Delete/5
        [Authorize(Roles = "Policaec")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ischeznat ischeznat = db.Ischeznats.Find(id);
            if (ischeznat == null)
            {
                return HttpNotFound();
            }
            var i = db.Ischeznats.Find(id);
            ViewBag.Ime = i.Ime;
            ViewBag.Prezime = i.Prezime;
            return View(ischeznat);
        }

        // POST: Ischeznats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Ischeznat ischeznat = db.Ischeznats.Find(id);
            db.Ischeznats.Remove(ischeznat);
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
