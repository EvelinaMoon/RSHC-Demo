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
    public class RSHCOffBoardingsController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCOffBoardings
        public async Task<ActionResult> Index()
        {
            var rSHCOffBoarding = db.RSHCOffBoarding.Include(r => r.RSHCEmployee);
            return View(await rSHCOffBoarding.ToListAsync());
        }

        // GET: RSHCOffBoardings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOffBoarding rSHCOffBoarding = await db.RSHCOffBoarding.FindAsync(id);
            if (rSHCOffBoarding == null)
            {
                return HttpNotFound();
            }
            return View(rSHCOffBoarding);
        }

        // GET: RSHCOffBoardings/Create
        public ActionResult Create()
        {
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID");
            return View();
        }

        // POST: RSHCOffBoardings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,OffBoardingStarted,OffBoardingCompleted,BoardingStatus,RSHCEmployeeId,RSHCDevicesReturned,O365WipeMobileDevices,O365PasswordChanged,O365ForceLogout,O365ClearContactInfo,O365AddTerminatedTitle,O365RemoveFromGroups,O365SetAutoreply,O365SetHideFromGAL,NetDoctsCheckInAllDocs,NetDocUserGUIDToWorksheet,NetDocCheckDeletedDocuments,NetDoCloseAuthorID,NetDocCheckPersonalMatter,NetDocDeleteMobileDevice,NetDocTermUser,AdobeAcrobatDeleteUser,FaxPlusDeleteUser,NordLayerDeleteUser,ITimekeepDeleteUser,SharefileDisableAccount,SharefileLicensed,SharefileRemoveLicense,SharefileFoldersToSupport,ZoomForwardToReception,PCWiped,KeycardsPhysicallyDisable,ChicagoInformBuilding,PSTArchiveContent,PSTSavedToPSTOrNAS,O365ZoomDeleteUser,DeleteO365ZoomUserBy")] RSHCOffBoarding rSHCOffBoarding)
        {
            if (ModelState.IsValid)
            {
                db.RSHCOffBoarding.Add(rSHCOffBoarding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOffBoarding.RSHCEmployeeId);
            return View(rSHCOffBoarding);
        }

        // GET: RSHCOffBoardings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOffBoarding rSHCOffBoarding = await db.RSHCOffBoarding.FindAsync(id);
            if (rSHCOffBoarding == null)
            {
                return HttpNotFound();
            }
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOffBoarding.RSHCEmployeeId);
            return View(rSHCOffBoarding);
        }

        // POST: RSHCOffBoardings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,OffBoardingStarted,OffBoardingCompleted,BoardingStatus,RSHCEmployeeId,RSHCDevicesReturned,O365WipeMobileDevices,O365PasswordChanged,O365ForceLogout,O365ClearContactInfo,O365AddTerminatedTitle,O365RemoveFromGroups,O365SetAutoreply,O365SetHideFromGAL,NetDoctsCheckInAllDocs,NetDocUserGUIDToWorksheet,NetDocCheckDeletedDocuments,NetDoCloseAuthorID,NetDocCheckPersonalMatter,NetDocDeleteMobileDevice,NetDocTermUser,AdobeAcrobatDeleteUser,FaxPlusDeleteUser,NordLayerDeleteUser,ITimekeepDeleteUser,SharefileDisableAccount,SharefileLicensed,SharefileRemoveLicense,SharefileFoldersToSupport,ZoomForwardToReception,PCWiped,KeycardsPhysicallyDisable,ChicagoInformBuilding,PSTArchiveContent,PSTSavedToPSTOrNAS,O365ZoomDeleteUser,DeleteO365ZoomUserBy")] RSHCOffBoarding rSHCOffBoarding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCOffBoarding).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOffBoarding.RSHCEmployeeId);
            return View(rSHCOffBoarding);
        }

        // GET: RSHCOffBoardings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOffBoarding rSHCOffBoarding = await db.RSHCOffBoarding.FindAsync(id);
            if (rSHCOffBoarding == null)
            {
                return HttpNotFound();
            }
            return View(rSHCOffBoarding);
        }

        // POST: RSHCOffBoardings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCOffBoarding rSHCOffBoarding = await db.RSHCOffBoarding.FindAsync(id);
            db.RSHCOffBoarding.Remove(rSHCOffBoarding);
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
