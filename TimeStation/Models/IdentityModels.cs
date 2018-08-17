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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Barcode { get; set; }

        public Department Department { get; set; }
        public Cohort Cohort { get; set; }
        public Campus Campus { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        //public DbSet<ApplicationUser> AspNetUsers { get; set; }   // ALREADY QUERYABLE

        public DbSet<Department> Departments { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Campus> Campuses { get; set; }



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
                .Property(user => user.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.LastName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(user => user.Barcode)
                .HasMaxLength(255);





            base.OnModelCreating(modelBuilder);
        }

    }
}