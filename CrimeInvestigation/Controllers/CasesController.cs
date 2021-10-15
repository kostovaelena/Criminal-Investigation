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
    public class CasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cases
        [Authorize(Roles = "Policaec")]
        public ActionResult Index()
        {
            return View(db.Cases.ToList());
        }



        [Authorize(Roles = "Policaec")]

        public ActionResult AddOsomnichenToCase(int id)
        {
            var model = new AddToCase();
            model.caseId = id;
            model.osomnicheni = db.Osomnichens.ToList();
            var casee = db.Cases.Find(id);
            ViewBag.CaseName = casee.Ime;
            ViewBag.ID = casee.ID;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOsomnichenToCase(AddToCase model)
        {
            var casee = db.Cases.Find(model.caseId);
            var osomnichen = db.Osomnichens.Find(model.osomnichenId);
            casee.osomnicheni.Add(osomnichen);
            db.SaveChanges();
            return View("Index", db.Cases.ToList());
        }



        [Authorize(Roles = "Policaec")]

        public ActionResult AddPolicaecToCase(int id)
        {
            var model2 = new AddToCase2();
            model2.caseId = id;
            model2.policajci= db.Policaecs.ToList();
            var casee = db.Cases.Find(id);
            ViewBag.CaseName = casee.Ime;
            ViewBag.ID = casee.ID;


            return View(model2);
        }

        [HttpPost]
        public ActionResult AddPolicaecToCase(AddToCase2 model2)
        {
            var casee = db.Cases.Find(model2.caseId);
            var policaec = db.Policaecs.Find(model2.policaecId);
            casee.policajci.Add(policaec);
            db.SaveChanges();
            return View("Index", db.Cases.ToList());
        }




        // GET: Cases/Details/5
        [Authorize(Roles = "Policaec")]
        public ActionResult Details(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            var casee = db.Cases.Find(id);
            ViewBag.Ime = casee.Ime;
            ViewBag.Prezime = casee.Prezime;
            ViewBag.ID = casee.ID;
            return View(@case);
        }

        // GET: Cases/Create
        [Authorize(Roles = "Korisnik")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Vreme,Lokacija,Tip,Opis,IsAvailable")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(@case);
                db.SaveChanges();
                return Redirect("/Home/Index");
            }

            return View(@case);
        }

        // GET: Cases/Edit/5
        [Authorize(Roles = "Policaec")]
        public ActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Vreme,Lokacija,Tip,Opis,IsAvailable")] Case @case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@case);
        }

        // GET: Cases/Delete/5
        [Authorize(Roles = "Policaec")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = db.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Case @case = db.Cases.Find(id);
            db.Cases.Remove(@case);
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
