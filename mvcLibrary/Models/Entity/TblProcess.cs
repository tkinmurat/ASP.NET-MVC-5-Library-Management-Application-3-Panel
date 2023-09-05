//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcLibrary.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblProcess()
        {
            this.TblBan = new HashSet<TblBan>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Book { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<int> Employee { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ReturnedDate { get; set; }
        public Nullable<bool> ProcessSituation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblBan> TblBan { get; set; }
        public virtual TblBook TblBook { get; set; }
        public virtual TblEmployee TblEmployee { get; set; }
        public virtual TblMembers TblMembers { get; set; }
    }
}
