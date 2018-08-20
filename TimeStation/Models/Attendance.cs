using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Attendance
    {

        public int AttendanceId { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime? TimeOut { get; set; }

        public TimeSpan? Duration { get; set; }

        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public string CohortId { get; set; }
        public Cohort Cohort { get; set; }


    }
}