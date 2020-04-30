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
    public class CrisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Crises
        public ActionResult Index()
        {
            return View(db.Crises.ToList());
        }

        // GET: Crises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crise crise = db.Crises.Find(id);
            if (crise == null)
            {
                return HttpNotFound();
            }
            return View(crise);
        }

        // GET: Crises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriseID,Type_Crise,Objet,Contenu")] Crise crise)
        {
            if (ModelState.IsValid)
            {
                db.Crises.Add(crise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crise);
        }

        // GET: Crises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crise crise = db.Crises.Find(id);
            if (crise == null)
            {
                return HttpNotFound();
            }
            return View(crise);
        }

        // POST: Crises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriseID,Type_Crise,Objet,Contenu")] Crise crise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crise);
        }

        // GET: Crises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crise crise = db.Crises.Find(id);
            if (crise == null)
            {
                return HttpNotFound();
            }
            return View(crise);
        }

        // POST: Crises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crise crise = db.Crises.Find(id);
            db.Crises.Remove(crise);
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
