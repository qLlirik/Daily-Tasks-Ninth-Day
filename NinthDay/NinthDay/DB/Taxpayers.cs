//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NinthDay.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taxpayers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taxpayers()
        {
            this.TaxPayment = new HashSet<TaxPayment>();
        }
    
        public int ID { get; set; }
        public string INN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Document { get; set; }
        public string Serial { get; set; }
        public string Number { get; set; }
        public System.DateTime Date { get; set; }
        public string Region { get; set; }
        public System.DateTime Born { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string DistrictTax { get; set; }
        public string TaxNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxPayment> TaxPayment { get; set; }
    }
}
