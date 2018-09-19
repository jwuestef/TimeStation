using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class ApplicationUserIndexViewModel
    {
        public string Barcode { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Campus { get; set; }
        public string Department { get; set; }
        public string Cohort { get; set; }
        public string Role { get; set; }

    }
}