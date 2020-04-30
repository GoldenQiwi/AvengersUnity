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
    public class CustomUserRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomUserRoles
        public ActionResult Index()
        {
            return View(db.CustomUserRoles.ToList());
        }

        // GET: CustomUserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserRole customUserRole = db.CustomUserRoles.Find(id);
            if (customUserRole == null)
            {
                return HttpNotFound();
            }
            return View(customUserRole);
        }

        // GET: CustomUserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomUserRoles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,RoleId")] CustomUserRole customUserRole)
        {
            if (ModelState.IsValid)
            {
                db.CustomUserRoles.Add(customUserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customUserRole);
        }

        // GET: CustomUserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserRole customUserRole = db.CustomUserRoles.Find(id);
            if (customUserRole == null)
            {
                return HttpNotFound();
            }
            return View(customUserRole);
        }

        // POST: CustomUserRoles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,RoleId")] CustomUserRole customUserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customUserRole);
        }

        // GET: CustomUserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomUserRole customUserRole = db.CustomUserRoles.Find(id);
            if (customUserRole == null)
            {
                return HttpNotFound();
            }
            return View(customUserRole);
        }

        // POST: CustomUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomUserRole customUserRole = db.CustomUserRoles.Find(id);
            db.CustomUserRoles.Remove(customUserRole);
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
