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
    [Authorize]
    public class RacesController : Controller
    {
        private DotRacesDataContext db = new DotRacesDataContext();

        // GET: Races
        public ActionResult Index()
        {
            return View(db.Races.OrderBy(x => x.SettingSetID).ThenBy(x => x.RaceNum).ToList());
        }

        // GET: Races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // GET: Races/Create
        public ActionResult Create(int? id)
        {
            SettingSet settings = db.SettingSets.Find(id);

            List<Race> races = db.Races.Where(x => x.SettingSetID == id).ToList();

            Race race = new Race();

            if (races.Count() < settings.NumberOfRaces)
            {
                race.RaceNum = races.Count() + 1;
            }

            race.SettingSetID = (int)id;

            return View(race);
        }

        // POST: Races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaceID,RaceNum,SettingSetID,Duration,Winner,Difference1,Difference2,Difference3,Difference4,Difference5,Difference6,Difference7,Difference8,Difference9,Difference10,Difference11,Difference12,Difference13,Difference14,Difference15,Difference16,Sound1ID,Sound2ID,Sound3ID,Sound4ID,Sound5ID,Sound6ID,Sound7ID,Sound8ID,Sound9ID,Sound10ID,Sound11ID,Sound12ID,Sound13ID,Sound14ID,Sound15ID,Sound16ID,SettingSetID")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(race);
                db.SaveChanges();
                return RedirectToAction("Index", "Settings");
            }

            return View(race);
        }

        // GET: Races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }


            List<SelectListItem> soundList = new List<SelectListItem>();

            soundList.Add(new SelectListItem
            {
                Text = "cheer1",
                Value = "1"
            });

            soundList.Add(new SelectListItem
            {
                Text = "cheer2",
                Value = "2"
            });

            soundList.Add(new SelectListItem
            {
                Text = "cheer3",
                Value = "3"
            });

            soundList.Add(new SelectListItem
            {
                Text = "crowd",
                Value = "4"
            });

            soundList.Add(new SelectListItem
            {
                Text = "pistol",
                Value = "5"
            });
            
             
            List<SelectListItem> intervalList = new List<SelectListItem>();

            for (double i = 3.0; i > 1; i -= .2)
            {
                SelectListItem interval = new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                intervalList.Add(interval);
            }

            intervalList.Add(new SelectListItem { Text = "1.0", Value = "1" });
            //intervalList.Add(new SelectListItem { Text = "0.9", Value = "0.9" });
            intervalList.Add(new SelectListItem { Text = "0.8", Value = "0.8" });
            //intervalList.Add(new SelectListItem { Text = "0.7", Value = "0.7" });
            intervalList.Add(new SelectListItem { Text = "0.6", Value = "0.6" });
            //intervalList.Add(new SelectListItem { Text = "0.5", Value = "0.5" });
            intervalList.Add(new SelectListItem { Text = "0.4", Value = "0.4" });
            //intervalList.Add(new SelectListItem { Text = "0.3", Value = "0.3" });
            intervalList.Add(new SelectListItem { Text = "0.2", Value = "0.2" });
            //intervalList.Add(new SelectListItem { Text = "0.1", Value = "0.1" });
            intervalList.Add(new SelectListItem { Text = "0.0", Value = "0" });
            //intervalList.Add(new SelectListItem { Text = "-0.1", Value = "-0.1" });
            intervalList.Add(new SelectListItem { Text = "-0.2", Value = "-0.2" });
            //intervalList.Add(new SelectListItem { Text = "-0.3", Value = "-0.3" });
            intervalList.Add(new SelectListItem { Text = "-0.4", Value = "-0.4" });
            //intervalList.Add(new SelectListItem { Text = "-0.5", Value = "-0.5" });
            intervalList.Add(new SelectListItem { Text = "-0.6", Value = "-0.6" });
            //intervalList.Add(new SelectListItem { Text = "-0.7", Value = "-0.7" });
            intervalList.Add(new SelectListItem { Text = "-0.8", Value = "-0.8" });
            //intervalList.Add(new SelectListItem { Text = "-0.9", Value = "-0.9" });
            intervalList.Add(new SelectListItem { Text = "-1.0", Value = "-1" });

            for (double i = -1.2; i > -3.2; i -= 0.2)
            {
                SelectListItem interval = new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                intervalList.Add(interval);
            }
            ViewData["intervals"] = intervalList;
            ViewData["sounds"] = soundList;
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceID,RaceNum,Duration,Winner,OtherDifference1,OtherDifference2,OtherDifference3,OtherDifference4,OtherDifference5,OtherDifference6,OtherDifference7,OtherDifference8,OtherDifference9,OtherDifference10,OtherDifference11,OtherDifference12,OtherDifference13,OtherDifference14,OtherDifference15,OtherDifference16,Difference1,Difference2,Difference3,Difference4,Difference5,Difference6,Difference7,Difference8,Difference9,Difference10,Difference11,Difference12,Difference13,Difference14,Difference15,Difference16,Sound1ID,Sound2ID,Sound3ID,Sound4ID,Sound5ID,Sound6ID,Sound7ID,Sound8ID,Sound9ID,Sound10ID,Sound11ID,Sound12ID,Sound13ID,Sound14ID,Sound15ID,Sound16ID,SettingSetID")] Race race)
        {
            if (ModelState.IsValid)
            {
                db.Entry(race).State = EntityState.Modified;
                db.SaveChanges();
            }

            List<SelectListItem> intervalList = new List<SelectListItem>();

            for (double i = 3.0; i > 1; i -= .2)
            {
                SelectListItem interval = new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                intervalList.Add(interval);
            }

            intervalList.Add(new SelectListItem { Text = "1.0", Value = "1" });
            //intervalList.Add(new SelectListItem { Text = "0.9", Value = "0.9" });
            intervalList.Add(new SelectListItem { Text = "0.8", Value = "0.8" });
            //intervalList.Add(new SelectListItem { Text = "0.7", Value = "0.7" });
            intervalList.Add(new SelectListItem { Text = "0.6", Value = "0.6" });
            //intervalList.Add(new SelectListItem { Text = "0.5", Value = "0.5" });
            intervalList.Add(new SelectListItem { Text = "0.4", Value = "0.4" });
            //intervalList.Add(new SelectListItem { Text = "0.3", Value = "0.3" });
            intervalList.Add(new SelectListItem { Text = "0.2", Value = "0.2" });
            //intervalList.Add(new SelectListItem { Text = "0.1", Value = "0.1" });
            intervalList.Add(new SelectListItem { Text = "0.0", Value = "0" });
            //intervalList.Add(new SelectListItem { Text = "-0.1", Value = "-0.1" });
            intervalList.Add(new SelectListItem { Text = "-0.2", Value = "-0.2" });
            //intervalList.Add(new SelectListItem { Text = "-0.3", Value = "-0.3" });
            intervalList.Add(new SelectListItem { Text = "-0.4", Value = "-0.4" });
            //intervalList.Add(new SelectListItem { Text = "-0.5", Value = "-0.5" });
            intervalList.Add(new SelectListItem { Text = "-0.6", Value = "-0.6" });
            //intervalList.Add(new SelectListItem { Text = "-0.7", Value = "-0.7" });
            intervalList.Add(new SelectListItem { Text = "-0.8", Value = "-0.8" });
            //intervalList.Add(new SelectListItem { Text = "-0.9", Value = "-0.9" });
            intervalList.Add(new SelectListItem { Text = "-1.0", Value = "-1" });

            for (double i = -1.2; i > -3.2; i -= 0.2)
            {
                SelectListItem interval = new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                intervalList.Add(interval);
            }
            ViewData["intervals"] = intervalList;
            return View(race);
        }

        public ActionResult PreviewRace(int? id)
        {
            Race race = db.Races.Find(id);
            RaceViewModel model = new RaceViewModel();

            model.Race = race;
            model.RaceID = race.RaceID;
            model.RaceNum = race.RaceNum;

            model.OSUWins = 0;
            model.UOWins = 0;

            model.CurrentPoints = 0;

            if (race.Winner)
            {
                model.AfterPoints = 5;
                model.AfterUOWins = 1;
                model.AfterOSUWins = 0;
            }
            else
            {
                model.AfterUOWins = 0;
                model.AfterOSUWins = 1;
            }

            if(race != null)
            {

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult PreviewRace(RaceViewModel model)
        {
            return RedirectToAction("Edit", "Races", new { id = model.RaceID });
        }

        // GET: Races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return HttpNotFound();
            }
            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Race race = db.Races.Find(id);
            db.Races.Remove(race);
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
