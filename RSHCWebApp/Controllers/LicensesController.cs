using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSHCEnteties;
using RSHCEnteties.DataAccessLayer;

namespace RSHCWebApp.Controllers
{
    [Authorize]
    public class LicensesController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: Licenses
        public ActionResult Index()
        {
            var licenses = db.Licenses.Include(l => l.Person);
            return View(licenses.ToList());
        }

        // GET: Licenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Trace.TraceError("Received an empty id for Licenses/Details");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Licenses/Details");

                //HttpNotFoundResult doesn't render a view.
                //return HttpNotFound();

                throw new HttpException(404, "Not found");
            }
            return View(license);
        }

        // GET: Licenses/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Persons, "UserID", "LastName");
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OwnerID,Description,Jurisdiction,License1")] License license)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Licenses.Add(license);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "Failed to add new record. " + ex.Message);
            }

            ViewBag.OwnerID = new SelectList(db.Persons, "UserID", "LastName", license.OwnerID);
            return View(license);
        }

        // GET: Licenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                Trace.TraceError("Received an empty id for Licenses/Edit");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Licenses/Edit");

                //HttpNotFoundResult doesn't render a view.
                //return HttpNotFound();

                throw new HttpException(404, "Not found");
            }
            ViewBag.OwnerID = new SelectList(db.Persons, "UserID", "LastName", license.OwnerID);
            return View(license);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OwnerID,Description,Jurisdiction,License1")] License license)
        {
            if (ModelState.IsValid)
            {
                db.Entry(license).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Persons, "UserID", "LastName", license.OwnerID);
            return View(license);
        }

        // GET: Licenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                Trace.TraceError("Received an empty id for Licenses/Delete");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Licenses/Delete");

                //HttpNotFoundResult doesn't render a view.
                //return HttpNotFound();

                throw new HttpException(404, "Not found");
            }
            return View(license);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            License license = db.Licenses.Find(id);
            db.Licenses.Remove(license);
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
