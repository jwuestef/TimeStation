using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TimeStation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public string Username { get; set; }  // ALREADY DEFINED BY DOTNET



        [Required(ErrorMessage = "Username is required.")]
        [StringLength(255, ErrorMessage = "Username must be less than 255 characters.")]
        [Display(Name = "Username")]
        public override string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(255, ErrorMessage = "First Name must be less than 255 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(255, ErrorMessage = "Last Name must be less than 255 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "That's not a valid email address")]
        public override string Email { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string CohortId { get; set; }
        public Cohort Cohort { get; set; }

        public string Barcode { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName));
            return userIdentity;
        }
    }










    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //public DbSet<ApplicationUser> AspNetUsers { get; set; }   // ALREADY QUERYABLE
        //public System.Data.Entity.DbSet<TimeStation.Models.ApplicationUser> ApplicationUsers { get; set; }   // THIS WAS AUTO ADDED WHEN I CREATED THE ApplicationUsersController AND
                                                                                                               // HAD IT AUTO-GENERATE VIEWS... HAD TO COMMENT THIS OUT
                                                                                                               // AND RENAME ALL 'db.ApplicationUsers.'etc... IN MY VIEWS TO BE
                                                                                                               // 'db.Users.'etc...


        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }



        public ApplicationDbContext()
            : base("TimeStationConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>()
                .Property(dept => dept.DepartmentName)
                .HasMaxLength(255)
                .IsRequired();



            modelBuilder.Entity<Cohort>()
                .Property(cohort => cohort.CohortId)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Cohort>()
                .Property(cohort => cohort.CohortName)
                .HasMaxLength(255)
                .IsRequired();



            modelBuilder.Entity<Campus>()
                .Property(campus => campus.CampusName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Campus>()
                .ToTable("Campuses");



            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.UserName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.LastName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.CampusId)
                .IsRequired();

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasRequired(au => au.Campus)

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.Barcode)
                .HasMaxLength(255);





            base.OnModelCreating(modelBuilder);
        }

    }
}