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

        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Display(Name = "Time Out")]
        public DateTime? TimeOut { get; set; }

        public TimeSpan? Duration { get; set; }

        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        public IEnumerable<Campus> Campuses { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        [Display(Name = "Cohort")]
        public string CohortId { get; set; }
        public IEnumerable<Cohort> Cohorts { get; set; }


    }
}