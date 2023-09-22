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
    public class RSHCOnBoardingsController : Controller
    {
        private RSHCDatabaseContext db = new RSHCDatabaseContext();

        // GET: RSHCOnBoardings
        public async Task<ActionResult> Index()
        {
            var rSHCOnBoarding = db.RSHCOnBoarding.Include(r => r.RSHCEmployee);
            return View(await rSHCOnBoarding.ToListAsync());
        }

        // GET: RSHCOnBoardings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOnBoarding rSHCOnBoarding = await db.RSHCOnBoarding.FindAsync(id);
            if (rSHCOnBoarding == null)
            {
                return HttpNotFound();
            }
            return View(rSHCOnBoarding);
        }

        // GET: RSHCOnBoardings/Create
        public ActionResult Create()
        {
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID");
            return View();
        }

        // POST: RSHCOnBoardings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,OnBoardingStarted,OnBoardingCompleted,RSHCEmployeeId,BoardingStatus,SerialNumber,ComputerName,RSHCAssetTag,CreateAdminaccount,TurnOffFeatures,Win10EnterpriseKey,SettingsUpdateGiveMe,Win10Updated,CheckForUpdates,NonSurfaceUpdates,AddAppsAccount,PrivateNetworkAllowSharing,Office64Bit,AcrobatDC,CiscoUmbrellaCertificate,Chrome,Firefox,ETranscriptViewer,VLCViewer,MSVisualStudioRuntime2010,MSVisualC4,ChangePro,Metadact,LiteraMetadact,DocXLitera,ContractCompanionLitera,NDOffice,NDClickChromeExtension,ndMail,Meraki,LogMeInClient,SophosReboot,PrivacyScreen,ProtectiveCase,SetTimeZone,JoinAzureAD,LoginUserPIN,InternetTurnOffTLS,BrowserTurnOffPasswordSaving,SetDefaultApps,DisableOneDrive,NetDocsRegistryKeys,NDOfficeIDStamp,LiteraSetMetadact,BackBitLockerAzureKey,OutlookTurnOffAutocomplete,AcrobatSetPDF,ZoomLogInUser,AttorneyiTimekeep,AddZebsOfficeTemplates,OutlookSignaturee,AddXerox,CopyMoveFiles,OutlookActivateSignature,AddPrinters,CitrixClient,SevenZip,ZoomClient")] RSHCOnBoarding rSHCOnBoarding)
        {
            if (ModelState.IsValid)
            {
                db.RSHCOnBoarding.Add(rSHCOnBoarding);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOnBoarding.RSHCEmployeeId);
            return View(rSHCOnBoarding);
        }

        // GET: RSHCOnBoardings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOnBoarding rSHCOnBoarding = await db.RSHCOnBoarding.FindAsync(id);
            if (rSHCOnBoarding == null)
            {
                return HttpNotFound();
            }
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOnBoarding.RSHCEmployeeId);
            return View(rSHCOnBoarding);
        }

        // POST: RSHCOnBoardings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,OnBoardingStarted,OnBoardingCompleted,RSHCEmployeeId,BoardingStatus,SerialNumber,ComputerName,RSHCAssetTag,CreateAdminaccount,TurnOffFeatures,Win10EnterpriseKey,SettingsUpdateGiveMe,Win10Updated,CheckForUpdates,NonSurfaceUpdates,AddAppsAccount,PrivateNetworkAllowSharing,Office64Bit,AcrobatDC,CiscoUmbrellaCertificate,Chrome,Firefox,ETranscriptViewer,VLCViewer,MSVisualStudioRuntime2010,MSVisualC4,ChangePro,Metadact,LiteraMetadact,DocXLitera,ContractCompanionLitera,NDOffice,NDClickChromeExtension,ndMail,Meraki,LogMeInClient,SophosReboot,PrivacyScreen,ProtectiveCase,SetTimeZone,JoinAzureAD,LoginUserPIN,InternetTurnOffTLS,BrowserTurnOffPasswordSaving,SetDefaultApps,DisableOneDrive,NetDocsRegistryKeys,NDOfficeIDStamp,LiteraSetMetadact,BackBitLockerAzureKey,OutlookTurnOffAutocomplete,AcrobatSetPDF,ZoomLogInUser,AttorneyiTimekeep,AddZebsOfficeTemplates,OutlookSignaturee,AddXerox,CopyMoveFiles,OutlookActivateSignature,AddPrinters,CitrixClient,SevenZip,ZoomClient")] RSHCOnBoarding rSHCOnBoarding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSHCOnBoarding).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RSHCEmployeeId = new SelectList(db.RSHCEmployee, "ID", "UserID", rSHCOnBoarding.RSHCEmployeeId);
            return View(rSHCOnBoarding);
        }

        // GET: RSHCOnBoardings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSHCOnBoarding rSHCOnBoarding = await db.RSHCOnBoarding.FindAsync(id);
            if (rSHCOnBoarding == null)
            {
                return HttpNotFound();
            }
            return View(rSHCOnBoarding);
        }

        // POST: RSHCOnBoardings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RSHCOnBoarding rSHCOnBoarding = await db.RSHCOnBoarding.FindAsync(id);
            db.RSHCOnBoarding.Remove(rSHCOnBoarding);
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
