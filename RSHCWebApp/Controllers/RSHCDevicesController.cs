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
    public class RSHCDevicesController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCDevices
        public async Task<ActionResult> Index()
        {
            return View(await db.RSHCDevice.ToListAsync());
        }

        // GET: RSHCDevices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDevice rSHCDevice = await db.RSHCDevice.FindAsync(id);
            if (rSHCDevice == null)
            {
                return HttpNotFound();
            }
            return View(rSHCDevice);
        }

        // GET: RSHCDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RSHCDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,SerialNumber,DeviceStatus,Brand,Model,RAM,SSDSize,ComputerName,BuildDate,Notes")] RSHCDevice rSHCDevice)
        {
            if (ModelState.IsValid)
            {
                db.RSHCDevice.Add(rSHCDevice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rSHCDevice);
        }

        // GET: RSHCDevices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDevice rSHCDevice = await db.RSHCDevice.FindAsync(id);
            if (rSHCDevice == null)
            {
                return HttpNotFound();
            }
            return View(rSHCDevice);
        }

        // POST: RSHCDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,SerialNumber,DeviceStatus,Brand,Model,RAM,SSDSize,ComputerName,BuildDate,Notes")] RSHCDevice rSHCDevice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCDevice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rSHCDevice);
        }

        // GET: RSHCDevices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCDevice rSHCDevice = await db.RSHCDevice.FindAsync(id);
            if (rSHCDevice == null)
            {
                return HttpNotFound();
            }
            return View(rSHCDevice);
        }

        // POST: RSHCDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCDevice rSHCDevice = await db.RSHCDevice.FindAsync(id);
            db.RSHCDevice.Remove(rSHCDevice);
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
