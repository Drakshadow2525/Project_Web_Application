//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProjectPetey.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.Orders_Details = new HashSet<Orders_Details>();
            this.SumCargoes = new HashSet<SumCargo>();
            this.Tops = new HashSet<Top>();
        }
    
        public int Product_Id { get; set; }
        public Nullable<int> Customer_id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Pro_date { get; set; }
        public System.DateTime Exp_date { get; set; }
        public string Brand { get; set; }
        public string Detalis { get; set; }
        public string Images { get; set; }
        public string Typess { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders_Details> Orders_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SumCargo> SumCargoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Top> Tops { get; set; }
    }
}
