//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_Food.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoServicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoServicio()
        {
            this.Servicios = new HashSet<Servicio>();
        }
    
        public int idTipoServicio { get; set; }
        public int idTipoAB { get; set; }
        public string nombreTS { get; set; }
        public Nullable<bool> inactive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicio> Servicios { get; set; }
        public virtual TipoAB TipoAB { get; set; }
    }
}
