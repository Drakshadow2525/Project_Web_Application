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
    
    public partial class Pet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pet()
        {
            this.Comments = new HashSet<Comment>();
            this.Orders_Details = new HashSet<Orders_Details>();
            this.SumCargoes = new HashSet<SumCargo>();
            this.Tops = new HashSet<Top>();
        }
    
        public int Pet_Id { get; set; }
        public int Customer_id { get; set; }
        public string Name { get; set; }
        public string Gene { get; set; }
        public string Sex { get; set; }
        public System.DateTime Birthdate { get; set; }
        public decimal Price { get; set; }
        public string History { get; set; }
        public string Images { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
        public string Images5 { get; set; }
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