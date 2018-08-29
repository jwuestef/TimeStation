using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeStation.Models;

// Import log4net classes.
using log4net;
using log4net.Config;

namespace TimeStation.Controllers
{
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // Define a static logger variable so that it references the
        // Logger instance named "MyApp".
        private static readonly ILog log = LogManager.GetLogger(typeof(AttendancesController));
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AttendancesController));  //Declaring Log4Net

        public AttendancesController()
        {
            // Set up a simple configuration that logs on the console.
            BasicConfigurator.Configure();
        }


        // GET: Attendances
        public ActionResult Index()
        {
            try
            {
                int x, y, z;
                x = 5; y = 0;
                z = x / y;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }

            log.Info("Entering application.");
            log.Warn("Entering application.");

            var users = db.Attendances
                .Include(att => att.ApplicationUser)
                .Include(att => att.Campus)
                .Include(att => att.Department)
                .Include(att => att.Cohort)
                .ToList();

            return View(users);
        }



        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }



        // GET: Attendances/Create
        public ActionResult Create()
        {
            var viewModel = new CreateAttendanceViewModel
            {
                ApplicationUsers = db.Users.ToList()
            };

            return View(viewModel);
        }



        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAttendanceViewModel attendanceViewModel)
        {
            if (ModelState.IsValid)
            {
                TimeSpan? duration = null;
                if (attendanceViewModel.TimeOut.HasValue)
                    duration = attendanceViewModel.TimeOut - attendanceViewModel.TimeIn;

                var user = db.Users.Single(u => u.Id == attendanceViewModel.ApplicationUserId);

                var newAttendance = new Attendance
                {
                    ApplicationUserId = attendanceViewModel.ApplicationUserId,
                    TimeIn = attendanceViewModel.TimeIn,
                    TimeOut = attendanceViewModel.TimeOut,
                    Duration = duration,
                    CampusId = user.CampusId,
                    DepartmentId = user.DepartmentId,
                    CohortId = user.CohortId
                };
                db.Attendances.Add(newAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendanceViewModel);
        }



        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }



        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceId,ApplicationUserId,TimeIn,TimeOut,Duration,CampusId,DepartmentId,CohortId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }



        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }



        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
