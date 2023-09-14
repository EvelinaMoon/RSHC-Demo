using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSHCEnteties.DataAccessLayer;
using RSHCEnteties.Enteties;

namespace RSHCWebApp.Controllers
{
    public class RSHCEmployeesController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCEmployees
        public async Task<ActionResult> Index()
        {
            var rSHCEmployee = db.RSHCEmployee.Include(r => r.OfficeLocation);
            return View(await rSHCEmployee.ToListAsync());
        }

        // GET: RSHCEmployees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCEmployee rSHCEmployee = await db.RSHCEmployee.FindAsync(id);
            if (rSHCEmployee == null)
            {
                return HttpNotFound();
            }
            return View(rSHCEmployee);
        }

        // GET: RSHCEmployees/Create
        public ActionResult Create()
        {
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue");
            return View();
        }

        // POST: RSHCEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,UserID,LastName,FirstName,MI,DisplayName,FullName,Initials,Title,Phone,PrivateEMail,RSHCEMail,AdmittedIn,AdmittedOut,OfficeLocationID")] RSHCEmployee rSHCEmployee)
        {
            if (ModelState.IsValid)
            {
                db.RSHCEmployee.Add(rSHCEmployee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCEmployee.OfficeLocationID);
            return View(rSHCEmployee);
        }

        // GET: RSHCEmployees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCEmployee rSHCEmployee = await db.RSHCEmployee.FindAsync(id);
            if (rSHCEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCEmployee.OfficeLocationID);
            return View(rSHCEmployee);
        }

        // POST: RSHCEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,UserID,LastName,FirstName,MI,DisplayName,FullName,Initials,Title,Phone,PrivateEMail,RSHCEMail,AdmittedIn,AdmittedOut,OfficeLocationID")] RSHCEmployee rSHCEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCEmployee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCEmployee.OfficeLocationID);
            return View(rSHCEmployee);
        }

        // GET: RSHCEmployees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCEmployee rSHCEmployee = await db.RSHCEmployee.FindAsync(id);
            if (rSHCEmployee == null)
            {
                return HttpNotFound();
            }
            return View(rSHCEmployee);
        }

        // POST: RSHCEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCEmployee rSHCEmployee = await db.RSHCEmployee.FindAsync(id);
            db.RSHCEmployee.Remove(rSHCEmployee);
            await db.SaveChangesAsync();
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
