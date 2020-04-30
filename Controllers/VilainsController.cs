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
    public class VilainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vilains
        public ActionResult Index()
        {
            return View(db.Vilains.ToList());
        }

        // GET: Vilains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vilain vilain = db.Vilains.Find(id);
            if (vilain == null)
            {
                return HttpNotFound();
            }
            return View(vilain);
        }

        // GET: Vilains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vilains/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VilainID,Nom,Pouvoir,Point_Faible,Commentaire")] Vilain vilain)
        {
            if (ModelState.IsValid)
            {
                db.Vilains.Add(vilain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vilain);
        }

        // GET: Vilains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vilain vilain = db.Vilains.Find(id);
            if (vilain == null)
            {
                return HttpNotFound();
            }
            return View(vilain);
        }

        // POST: Vilains/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VilainID,Nom,Pouvoir,Point_Faible,Commentaire")] Vilain vilain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vilain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vilain);
        }

        // GET: Vilains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vilain vilain = db.Vilains.Find(id);
            if (vilain == null)
            {
                return HttpNotFound();
            }
            return View(vilain);
        }

        // POST: Vilains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vilain vilain = db.Vilains.Find(id);
            db.Vilains.Remove(vilain);
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
