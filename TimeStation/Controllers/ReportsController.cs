using log4net;
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
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static readonly ILog log = LogManager.GetLogger(typeof(AttendancesController));



        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }



        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return View("Index");
            }

            log.Info(query);

            //Attendance attendance = db.Attendances.SqlQuery(query).SingleOrDefault();

            //if (attendance == null)
            //{
            //    return HttpNotFound();
            //}

            var returnedValues = db.Database.ExecuteSqlCommand("SELECT * FROM dbo.\"Attendances\"").ToString();
            //var returnedValues = db.Database.ExecuteSqlCommand("SELECT * FROM abcde");
            var returnedValues2 = db.Attendances.SqlQuery("SELECT * FROM dbo.\"Attendances\"").ToList();

            var returnedValues3 = db.Database.SqlQuery<object>("SELECT * from dbo.\"Attendances\"").ToList();



            return View("Index");
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
