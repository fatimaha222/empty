//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace empty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.Table = new HashSet<Table>();
        }
    
        public int CID { get; set; }
        public string Cname { get; set; }
        public string Ctype { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> EDate { get; set; }
        public string password { get; set; }
        public Nullable<int> capital { get; set; }
        public string logo { get; set; }
        public string Curl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table> Table { get; set; }
    }
}
