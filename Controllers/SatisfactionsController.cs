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
    public class SatisfactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Satisfactions
        public ActionResult Index()
        {
            var satisfactions = db.Satisfactions.Include(s => s.Mission).Include(s => s.User);
            return View(satisfactions.ToList());
        }

        // GET: Satisfactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = db.Satisfactions.Find(id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            return View(satisfaction);
        }

        // GET: Satisfactions/Create
        public ActionResult Create()
        {
            ViewBag.SatisfactionID = new SelectList(db.Missions, "MissionID", "Titre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Satisfactions/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisfactionID,UserId,Titre,Identification_Heros,Niveau,Note,Contenu")] Satisfaction satisfaction)
        {
            if (ModelState.IsValid)
            {
                db.Satisfactions.Add(satisfaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SatisfactionID = new SelectList(db.Missions, "MissionID", "Titre", satisfaction.SatisfactionID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", satisfaction.UserId);
            return View(satisfaction);
        }

        // GET: Satisfactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = db.Satisfactions.Find(id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.SatisfactionID = new SelectList(db.Missions, "MissionID", "Titre", satisfaction.SatisfactionID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", satisfaction.UserId);
            return View(satisfaction);
        }

        // POST: Satisfactions/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisfactionID,UserId,Titre,Identification_Heros,Niveau,Note,Contenu")] Satisfaction satisfaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisfaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SatisfactionID = new SelectList(db.Missions, "MissionID", "Titre", satisfaction.SatisfactionID);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", satisfaction.UserId);
            return View(satisfaction);
        }

        // GET: Satisfactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Satisfaction satisfaction = db.Satisfactions.Find(id);
            if (satisfaction == null)
            {
                return HttpNotFound();
            }
            return View(satisfaction);
        }

        // POST: Satisfactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Satisfaction satisfaction = db.Satisfactions.Find(id);
            db.Satisfactions.Remove(satisfaction);
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
