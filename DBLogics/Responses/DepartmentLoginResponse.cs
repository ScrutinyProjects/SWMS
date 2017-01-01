using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogics.Responses
{
    public class DepartmentLoginResponse
    {
        public int StatusID { get; set; }

        public string StatusMessage { get; set; }

        public int UserID { get; set; }

        public string OTP { get; set; }
    }

    public class DepartmentLoginDetailsResponse
    {
        public int StatusID { get; set; }

        public string StatusMessage { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }

        public long LoginID { get; set; }

        public string Masters { get; set; }

        public string LastTripDate { get; set; } 
    }
}
