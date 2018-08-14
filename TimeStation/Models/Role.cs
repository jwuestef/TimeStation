using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeStation.Models
{
    public class Role
    {
        // These are here to stop us using 0 and 1 in the code. Could use an enum too, but it would be a little more complicated... easier to do this
        public static readonly byte Guest = 0;
        public static readonly byte Student = 1;
        public static readonly byte Staff = 2;
        public static readonly byte Admin = 3;
    }
}