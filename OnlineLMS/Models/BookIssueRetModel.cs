using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Models
{
    public class BookIssueRetModel
    {
        public int BookIssueReturnID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> AssesionID { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public string FineAmount { get; set; }
        public string Status { get; set; }
        public Nullable<int> StaffMemberID { get; set; }
        public string Remarks { get; set; }
    }
}