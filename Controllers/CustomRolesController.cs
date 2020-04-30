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
    public class CustomRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomRoles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: CustomRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // GET: CustomRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomRoles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CustomRole customRole)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(customRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customRole);
        }

        // GET: CustomRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // POST: CustomRoles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CustomRole customRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customRole);
        }

        // GET: CustomRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // POST: CustomRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomRole customRole = db.Roles.Find(id);
            db.Roles.Remove(customRole);
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
