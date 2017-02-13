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
    public class SeparatorsController : Controller
    {
        private DotRacesDataContext db = new DotRacesDataContext();

        // GET: Separators
        public ActionResult Index()
        {
            return View(db.Separators.ToList());
        }

        // GET: Separators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Separator separator = db.Separators.Find(id);
            if (separator == null)
            {
                return HttpNotFound();
            }
            return View(separator);
        }

        // GET: Separators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Separators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeparatorID,CurrentVersion")] Separator separator)
        {
            if (ModelState.IsValid)
            {
                db.Separators.Add(separator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(separator);
        }

        // GET: Separators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Separator separator = db.Separators.Find(id);
            if (separator == null)
            {
                return HttpNotFound();
            }
            return View(separator);
        }

        // POST: Separators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeparatorID,CurrentVersion")] Separator separator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(separator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(separator);
        }

        // GET: Separators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Separator separator = db.Separators.Find(id);
            if (separator == null)
            {
                return HttpNotFound();
            }
            return View(separator);
        }

        // POST: Separators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Separator separator = db.Separators.Find(id);
            db.Separators.Remove(separator);
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
