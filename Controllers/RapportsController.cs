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
    public class RapportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rapports
        public ActionResult Index()
        {
            var rapports = db.Rapports.Include(r => r.Mission).Include(r => r.User);
            return View(rapports.ToList());
        }

        // GET: Rapports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            return View(rapport);
        }

        // GET: Rapports/Create
        public ActionResult Create()
        {
            ViewBag.RapportID = new SelectList(db.Missions, "MissionID", "Titre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Rapports/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RapportID,UserId,Description")] Rapport rapport)
        {
            if (ModelState.IsValid)
            {
                db.Rapports.Add(rapport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RapportID = new SelectList(db.Missions, "MissionID", "Titre", rapport.RapportID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", rapport.UserId);
            return View(rapport);
        }

        // GET: Rapports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            ViewBag.RapportID = new SelectList(db.Missions, "MissionID", "Titre", rapport.RapportID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", rapport.UserId);
            return View(rapport);
        }

        // POST: Rapports/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RapportID,UserId,Description")] Rapport rapport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rapport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RapportID = new SelectList(db.Missions, "MissionID", "Titre", rapport.RapportID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", rapport.UserId);
            return View(rapport);
        }

        // GET: Rapports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapport rapport = db.Rapports.Find(id);
            if (rapport == null)
            {
                return HttpNotFound();
            }
            return View(rapport);
        }

        // POST: Rapports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rapport rapport = db.Rapports.Find(id);
            db.Rapports.Remove(rapport);
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
