//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmacyApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            this.MedicineToTags = new HashSet<MedicineToTag>();
            this.Orders = new HashSet<Order>();
        }
    
        public int ID { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public string Description { get; set; }
        public bool IsReceipt { get; set; }
        public System.DateTime ProDate { get; set; }
        public System.DateTime ExperienceDate { get; set; }
        public string Barcode { get; set; }
        public Nullable<int> FirmID { get; set; }
    
        public virtual Firm Firm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicineToTag> MedicineToTags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
