using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Models
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public int StaffMemberID { get; set; }
        public string MemberAddress { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}