using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotRacesAdministration.DAL;
using DotRacesAdministration.Models;

namespace DotRacesAdministration.Controllers
{
    public class SettingsController : Controller
    {
        private DotRacesDataContext db = new DotRacesDataContext();

        // GET: Settings
        public ActionResult Index()
        {
            return View(db.SettingSets.ToList());
        }

        // GET: Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingSet settingSet = db.SettingSets.Find(id);
            if (settingSet == null)
            {
                return HttpNotFound();
            }
            return View(settingSet);
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SettingSetID,Name,Description,DefaultSetFlag,PotentialHighScore,PotentialLowScore,PointsPerRound,NumberOfRaces,NumberOfRacesText,NumberOfRacesAdjective,LastRaceMultiplier")] SettingSet settingSet)
        {
            if (ModelState.IsValid)
            {
                db.SettingSets.Add(settingSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(settingSet);
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingSet settingSet = db.SettingSets.Find(id);
            if (settingSet == null)
            {
                return HttpNotFound();
            }
            return View(settingSet);
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SettingSetID,Name,Description,DefaultSetFlag,PotentialHighScore,PotentialLowScore,PointsPerRound,NumberOfRaces,NumberOfRacesText,NumberOfRacesAdjective,LastRaceMultiplier")] SettingSet settingSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settingSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(settingSet);
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SettingSet settingSet = db.SettingSets.Find(id);
            if (settingSet == null)
            {
                return HttpNotFound();
            }
            return View(settingSet);
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SettingSet settingSet = db.SettingSets.Find(id);
            db.SettingSets.Remove(settingSet);
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
