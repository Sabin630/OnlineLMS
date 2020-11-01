using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLMS.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public Nullable<int> BookCategoryID { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public string Remarks { get; set; }
    }
}