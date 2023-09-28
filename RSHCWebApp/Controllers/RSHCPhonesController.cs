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
    public class RSHCPhonesController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCPhones
        public async Task<ActionResult> Index()
        {
            var rSHCPhone = db.RSHCPhone.Include(r => r.OfficeLocation);
          
            await rSHCPhone.ToListAsync();

            return View(rSHCPhone);
        }

        // GET: RSHCPhones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCPhone rSHCPhone = await db.RSHCPhone.FindAsync(id);
            if (rSHCPhone == null)
            {
                return HttpNotFound();
            }
            return View(rSHCPhone);
        }

        // GET: RSHCPhones/Create
        public ActionResult Create()
        {
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue");
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID");
            return View();
        }

        // POST: RSHCPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Phone,isAssigned,Status,Notes,PreviousUsers,Extension,Tier,TierDepartment,RSHCEMail,RSHCEmployeeId,OfficeLocationID")] RSHCPhone rSHCPhone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RSHCPhone.Add(rSHCPhone);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError("", "Failed to add new record. " + ex.Message);
            }

            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCPhone.OfficeLocationID);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCPhone.RSHCEmployeeId);
            return View(rSHCPhone);
        }

        // GET: RSHCPhones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCPhone rSHCPhone = await db.RSHCPhone.FindAsync(id);
            if (rSHCPhone == null)
            {
                return HttpNotFound();
            }
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCPhone.OfficeLocationID);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCPhone.RSHCEmployeeId);
            return View(rSHCPhone);
        }

        // POST: RSHCPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Phone,isAssigned,Status,Notes,PreviousUsers,Extension,Tier,TierDepartment,RSHCEMail,RSHCEmployeeId,OfficeLocationID")] RSHCPhone rSHCPhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCPhone).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OfficeLocationID = new SelectList(db.OfficeLocations, "ID", "OfficeValue", rSHCPhone.OfficeLocationID);
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCPhone.RSHCEmployeeId);
            return View(rSHCPhone);
        }

        // GET: RSHCPhones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCPhone rSHCPhone = await db.RSHCPhone.FindAsync(id);
            if (rSHCPhone == null)
            {
                return HttpNotFound();
            }
            return View(rSHCPhone);
        }

        // POST: RSHCPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCPhone rSHCPhone = await db.RSHCPhone.FindAsync(id);
            db.RSHCPhone.Remove(rSHCPhone);
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
