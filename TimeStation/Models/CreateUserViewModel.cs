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

        [Required(ErrorMessage = "Campus is required.")]
        public int Campus { get; set; }
        public IEnumerable<Campus> Campuses { get; set; }

        //[Required(ErrorMessage = "Department is required.")]
        public int Department { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public string Cohort { get; set; }
        public IEnumerable<Cohort> Cohorts { get; set; }

        public string Barcode { get; set; }



    }
}