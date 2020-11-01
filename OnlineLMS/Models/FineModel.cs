using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Models
{
    public class FineModel
    {
        public int FineID { get; set; }
        public Nullable<int> LateDays { get; set; }
        public Nullable<int> StaffMemberID { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
    }
}