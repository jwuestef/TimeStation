using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeStation.Models;

namespace TimeStation.Controllers
{
    public class CampusesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campuses
        public ActionResult Index()
        {
            return View(db.Campuses.ToList());
        }

        // GET: Campuses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Campuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampusId,CampusName")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campuses.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        // GET: Campuses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampusId,CampusName")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campus);
        }

        // GET: Campuses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campuses.Find(id);
            db.Campuses.Remove(campus);
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
