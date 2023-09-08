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
    public class PersonController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: Person
        public ActionResult Index()
        {
            var persons = db.Persons.Include(p => p.OfficeLocation);
            return View(persons.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                Trace.TraceError("Received an empty id for Person/Details/");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Where(p => p.ID == id).FirstOrDefault();
            if (person == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Person/Details");

                //HttpNotFoundResult doesn't render a view.
                return HttpNotFound();

                //throw new HttpException(404, "Not found");
            }
            return View(person);
        }

        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        Trace.TraceError("Received an empty id for Person/Details/");

        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
            
        //    Person person = db.Persons.Find(id);
          
        //    if (person == null)
        //    {
        //        Trace.TraceError("Failed to locate  " + id + " in Person/Details");

        //        //HttpNotFoundResult doesn't render a view.
        //        return HttpNotFound();

        //        //throw new HttpException(404, "Not found");
        //    }
        //    return View(person);
        //}

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.OfficeID = new SelectList(db.OfficeLocations, "ID", "OfficeValue");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,ID,LastName,FirstName,MI,DisplayName,FullName,Initials,OfficeID,ShortName,IsAttorney,IsAuthor,Title,Phone,Fax,EMail,AdmittedIn")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OfficeID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", person.OfficeID);
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                Trace.TraceError("Received an empty id for Person/Edit/");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Person person = db.Persons.Find(id);
            Person person = db.Persons.Where(p => p.ID == id).FirstOrDefault();
            if (person == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Person/Edit");

                //HttpNotFoundResult doesn't render a view.
                return HttpNotFound();

                //throw new HttpException(404, "Not found");
            }
            ViewBag.OfficeID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", person.OfficeID);
            return View(person);
        }


        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        Trace.TraceError("Received an empty id for Person/Edit/");

        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //     Person person = db.Persons.Find(id);
           
        //    if (person == null)
        //    {
        //        Trace.TraceError("Failed to locate  " + id + " in Person/Edit");

        //        //HttpNotFoundResult doesn't render a view.
        //        return HttpNotFound();

        //        //throw new HttpException(404, "Not found");
        //    }
        //    ViewBag.OfficeID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", person.OfficeID);
        //    return View(person);
        //}

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,ID,LastName,FirstName,MI,DisplayName,FullName,Initials,OfficeID,ShortName,IsAttorney,IsAuthor,Title,Phone,Fax,EMail,AdmittedIn")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OfficeID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", person.OfficeID);
            return View(person);
        }

        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                Trace.TraceError("Received an empty id for Person/Delete/");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Where(p => p.ID == id).FirstOrDefault();

            if (person == null)
            {
                Trace.TraceError("Failed to locate  " + id + " in Person/Delete");

                //HttpNotFoundResult doesn't render a view.
                //return HttpNotFound();

                throw new HttpException(404, "Not found");
            }
            return View(person);
        }


        //// GET: Person/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        Trace.TraceError("Received an empty id for Person/Delete/");

        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Person person = db.Persons.Find(id);
        //    if (person == null)
        //    {
        //        Trace.TraceError("Failed to locate  " + id + " in Person/Delete");

        //        //HttpNotFoundResult doesn't render a view.
        //        return HttpNotFound();

        //       // throw new HttpException(404, "Not found");
        //    }
        //    return View(person);
        //}

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
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
