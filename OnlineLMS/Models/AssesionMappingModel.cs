using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Models
{
    public class AssesionMappingModel
    {
        public int AssesionID { get; set; }
        public Nullable<int> BookID { get; set; }
        public string Status { get; set; }
    }
}