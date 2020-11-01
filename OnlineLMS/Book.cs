//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineLMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.AssesionMappings = new HashSet<AssesionMapping>();
        }
    
        public int BookID { get; set; }
        public string BookName { get; set; }
        public Nullable<int> BookCategoryID { get; set; }
        public Nullable<int> AuthorID { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssesionMapping> AssesionMappings { get; set; }
        public virtual Author Author { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
