using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Campus
    {
        public int CampusId { get; set; }

        [Required(ErrorMessage = "Campus Name is required.")]
        [StringLength(255, ErrorMessage = "Campus Name must be less than 255 characters.")]
        [Display(Name = "Campus Name")]
        public string CampusName { get; set; }


    }
}