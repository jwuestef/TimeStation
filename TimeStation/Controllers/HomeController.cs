using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeStation.Models;

namespace TimeStation.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ViewKiosk()
        {
            return View("Kiosk");
        }



        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kiosk kiosk)
        {
            if (ModelState.IsValid)
            {

                var user = db.Users
                    .Include(us => us.Campus)
                    .Include(us => us.Department)
                    .Include(us => us.Cohort)
                    .SingleOrDefault(us => us.Barcode == kiosk.Barcode);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Barcode");
                    return View("Kiosk", kiosk);
                }

                var userId = user.Id;

                var openAttendance = db.Attendances
                    .Where(att => att.ApplicationUserId == userId)
                    .SingleOrDefault(att => att.TimeOut == null);

                if (openAttendance == null)
                {
                    // We did not find an open attendance item for this user, create a new one.
                    return RedirectToAction("ViewKiosk");
                }
                else
                {
                    // We DID find an open attendance item for this user. Mark the current time as the timeout and calcuate the duration.
                    return RedirectToAction("ViewKiosk");
                }



            }

            return View("Kiosk", kiosk);
        }



    }
}