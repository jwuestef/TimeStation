using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Attendance
    {

        public int AttendanceId { get; set; }

        [Display(Name = "User")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Display(Name = "Time Out")]
        public DateTime? TimeOut { get; set; }

        public TimeSpan? Duration { get; set; }

        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Cohort")]
        public string CohortId { get; set; }
        public Cohort Cohort { get; set; }


    }
}