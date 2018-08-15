using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public string UserId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public TimeSpan? Duration { get; set; }


    }
}