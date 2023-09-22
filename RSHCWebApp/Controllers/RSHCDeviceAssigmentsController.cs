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
    [Authorize]
    public class RSHCDeviceAssigmentsController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCDeviceAssigments
        public async Task<ActionResult> Index()
        {
            var rSHCDeviceAssigment = db.RSHCDeviceAssigment.Include(r => r.RSHCDevice).Include(r => r.RSHCEmployee);
            return View(await rSHCDeviceAssigment.ToListAsync());
        }

        // GET: RSHCDeviceAssigments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDeviceAssigment rSHCDeviceAssigment = await db.RSHCDeviceAssigment.FindAsync(id);
            if (rSHCDeviceAssigment == null)
            {
                return HttpNotFound();
            }
            return View(rSHCDeviceAssigment);
        }

        // GET: RSHCDeviceAssigments/Create
        public ActionResult Create()
        {
            ViewBag.RSHCDeviceId = new SelectList(db.RSHCDevice, "ID", "SerialNumber");
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID");
            return View();
        }

        // POST: RSHCDeviceAssigments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AssignedDate,Status,Notes,RSHCEmployeeId,RSHCDeviceId")] RSHCDeviceAssigment rSHCDeviceAssigment)
        {
            if (ModelState.IsValid)
            {
                db.RSHCDeviceAssigment.Add(rSHCDeviceAssigment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RSHCDeviceId = new SelectList(db.RSHCDevice, "ID", "SerialNumber", rSHCDeviceAssigment.RSHCDeviceId);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCDeviceAssigment.RSHCEmployeeId);
            return View(rSHCDeviceAssigment);
        }

        // GET: RSHCDeviceAssigments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDeviceAssigment rSHCDeviceAssigment = await db.RSHCDeviceAssigment.FindAsync(id);
            if (rSHCDeviceAssigment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RSHCDeviceId = new SelectList(db.RSHCDevice, "ID", "SerialNumber", rSHCDeviceAssigment.RSHCDeviceId);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCDeviceAssigment.RSHCEmployeeId);
            return View(rSHCDeviceAssigment);
        }

        // POST: RSHCDeviceAssigments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AssignedDate,Status,Notes,RSHCEmployeeId,RSHCDeviceId")] RSHCDeviceAssigment rSHCDeviceAssigment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCDeviceAssigment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RSHCDeviceId = new SelectList(db.RSHCDevice, "ID", "SerialNumber", rSHCDeviceAssigment.RSHCDeviceId);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCDeviceAssigment.RSHCEmployeeId);
            return View(rSHCDeviceAssigment);
        }

        // GET: RSHCDeviceAssigments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDeviceAssigment rSHCDeviceAssigment = await db.RSHCDeviceAssigment.FindAsync(id);
            if (rSHCDeviceAssigment == null)
            {
                return HttpNotFound();
            }
            return View(rSHCDeviceAssigment);
        }

        // POST: RSHCDeviceAssigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCDeviceAssigment rSHCDeviceAssigment = await db.RSHCDeviceAssigment.FindAsync(id);
            db.RSHCDeviceAssigment.Remove(rSHCDeviceAssigment);
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
