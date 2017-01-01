using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogics.Responses
{
    public class RegistrationResponse
    {
        public int StatusID { get; set; }

        public string StatusMessage { get; set; }

        public int RegistrationID { get; set; }

        public string OTP { get; set; }
    }
}
