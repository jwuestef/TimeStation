using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Cohort
    {

        [Required(ErrorMessage = "Cohort ID is required.")]
        [StringLength(255, ErrorMessage = "Cohort ID must be less than 255 characters.")]
        [Display(Name = "Cohort ID")]
        public string CohortId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name must be less than 255 characters.")]
        [Display(Name = "Name")]
        public string CohortName { get; set; }


    }
}