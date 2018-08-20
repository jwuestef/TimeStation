using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(255, ErrorMessage = "Username must be less than 255 characters.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

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
        public string Email { get; set; }

        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        public IEnumerable<Campus> Campuses { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        // Strings are nullable, so this is OPTIONAL BY DEFAULT. Add [Required] if you want it mandatory. 
        // Integers aren't nullable, so CampusId and DepartmentId are REQUIRED BY DEFAULT. Add ? to be int? to make it optional
        [Display(Name = "Cohort")]
        public string CohortId { get; set; }
        public IEnumerable<Cohort> Cohorts { get; set; }

        public string Barcode { get; set; }



    }
}