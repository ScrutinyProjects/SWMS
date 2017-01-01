using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogics.Responses
{
    public class ComplaintsResponse
    {
        public int CompliantID { get; set; }

        public int ComplaintTypeID { get; set; }

        public string ComplaintType { get; set; }

        public int CompliantStatusID { get; set; }

        public string CompliantStatus { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ImagePath { get; set; }

        public string ComplainedDate { get; set; }

        public int PendingDays { get; set; }
    }
}
