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
    public class BegstvoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Begstvoes
        public ActionResult Index()
        {
            return View(db.Begstvoes.ToList());
        }

        // GET: Begstvoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Begstvo begstvo = db.Begstvoes.Find(id);
            if (begstvo == null)
            {
                return HttpNotFound();
            }
            return View(begstvo);
        }

        // GET: Begstvoes/Create
        [Authorize(Roles = "Policaec")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Begstvoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ime,Prezime,Godini,Slika,Datum,Mesto")] Begstvo begstvo)
        {
            if (ModelState.IsValid)
            {
                db.Begstvoes.Add(begstvo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(begstvo);
        }

        // GET: Begstvoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Begstvo begstvo = db.Begstvoes.Find(id);
            if (begstvo == null)
            {
                return HttpNotFound();
            }
            return View(begstvo);
        }

        // POST: Begstvoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ime,Prezime,Godini,Slika,Datum,Mesto")] Begstvo begstvo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(begstvo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(begstvo);
        }

        // GET: Begstvoes/Delete/5
        [Authorize(Roles = "Policaec")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Begstvo begstvo = db.Begstvoes.Find(id);
            if (begstvo == null)
            {
                return HttpNotFound();
            }
            return View(begstvo);
        }

        // POST: Begstvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Begstvo begstvo = db.Begstvoes.Find(id);
            db.Begstvoes.Remove(begstvo);
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
