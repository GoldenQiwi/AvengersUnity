using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvengersUnityIdentity.Models;

namespace AvengersUnityIdentity.Controllers
{
    public class HerosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Heros
        public ActionResult Index()
        {
            var heros = db.Heros.Include(h => h.Civil);
            return View(heros.ToList());
        }

        // GET: Heros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heros heros = db.Heros.Find(id);
            if (heros == null)
            {
                return HttpNotFound();
            }
            return View(heros);
        }

        // GET: Heros/Create
        public ActionResult Create()
        {
            ViewBag.HeroID = new SelectList(db.Civils, "CivilID", "Prenom");
            return View();
        }

        // POST: Heros/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeroID,Nom,Pouvoir,Point_Faible,Commentaire")] Heros heros)
        {
            if (ModelState.IsValid)
            {
                db.Heros.Add(heros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HeroID = new SelectList(db.Civils, "CivilID", "Prenom", heros.HeroID);
            return View(heros);
        }

        // GET: Heros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heros heros = db.Heros.Find(id);
            if (heros == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeroID = new SelectList(db.Civils, "CivilID", "Prenom", heros.HeroID);
            return View(heros);
        }

        // POST: Heros/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeroID,Nom,Pouvoir,Point_Faible,Commentaire")] Heros heros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HeroID = new SelectList(db.Civils, "CivilID", "Prenom", heros.HeroID);
            return View(heros);
        }

        // GET: Heros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heros heros = db.Heros.Find(id);
            if (heros == null)
            {
                return HttpNotFound();
            }
            return View(heros);
        }

        // POST: Heros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heros heros = db.Heros.Find(id);
            db.Heros.Remove(heros);
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
