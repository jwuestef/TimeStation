using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class CreateAttendanceViewModel
    {

        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "User is required.")]
        [Display(Name = "User")]
        public string ApplicationUserId { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

        [Required(ErrorMessage = "DateTime In is required.")]
        [Display(Name = "DateTime In")]
        public DateTime TimeIn { get; set; }

        [Display(Name = "DateTime Out")]
        public DateTime? TimeOut { get; set; }



    }
}