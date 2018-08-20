using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TimeStation.Models;

namespace TimeStation.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUserManager UserManager { get; private set; }


        // GET: ApplicationUsers
        public ActionResult Index()
        {
            // BEGIN - When we visit this User Management page, make sure the appropriate roles exist in the database
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("Guest"))
            {
                var role = new IdentityRole();
                role.Name = "Guest";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Kiosk"))
            {
                var role = new IdentityRole();
                role.Name = "Kiosk";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Staff"))
            {
                var role = new IdentityRole();
                role.Name = "Staff";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            // END - When we visit this User Management page, make sure the appropriate roles exist in the database

            var users = db.Users
                .Include(user => user.Department)
                .Include(user => user.Cohort)
                .Include(user => user.Campus)
                .ToList();

            return View(users);

        }



        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }



        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {

            var viewModel = new CreateUserViewModel
            {
                Campuses = db.Campuses.ToList(),
                Departments = db.Departments.ToList(),
                Cohorts = db.Cohorts.ToList()
            };

            return View(viewModel);
        }



        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel createUserViewModel)
        {


            if (ModelState.IsValid)
            {
                //var SelectedCampus = db.Campuses.Single(camp => camp.CampusId == createUserViewModel.CampusId);
                //var SelectedDepartment = db.Departments.Single(dept => dept.DepartmentId == createUserViewModel.DepartmentId);
                //var SelectedCohort = db.Cohorts.SingleOrDefault(cohort => cohort.CohortId == createUserViewModel.CohortId);

                var user = new ApplicationUser()
                {
                    UserName = createUserViewModel.UserName,
                    FirstName = createUserViewModel.FirstName,
                    LastName = createUserViewModel.LastName,
                    Email = createUserViewModel.Email,
                    CampusId = createUserViewModel.CampusId,
                    DepartmentId = createUserViewModel.DepartmentId,
                    CohortId = createUserViewModel.CohortId,
                    Barcode = createUserViewModel.Barcode

                };
                var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

                var result = await UserManager.CreateAsync(user, "Testing123!");
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "ApplicationUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }



            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "ERROR - unable to save user to DB for unknown reason. Redisplay the form with the same values...");

            var viewModel = new CreateUserViewModel
            {
                UserName = createUserViewModel.UserName,
                FirstName = createUserViewModel.FirstName,
                LastName = createUserViewModel.LastName,
                Email = createUserViewModel.Email,
                CampusId = createUserViewModel.CampusId,
                Campuses = db.Campuses.ToList(),
                DepartmentId = createUserViewModel.DepartmentId,
                Departments = db.Departments.ToList(),
                CohortId = createUserViewModel.CohortId,
                Cohorts = db.Cohorts.ToList(),
                Barcode = createUserViewModel.Barcode
            };

            return View(viewModel);





        }



        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }



        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Barcode,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }



        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }



        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
