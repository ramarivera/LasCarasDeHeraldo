//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LasCarasDeHeraldo
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReclamoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReclamoSet()
        {
            this.HistoricoSets = new HashSet<HistoricoSet>();
            this.UsuarioSets = new HashSet<UsuarioSet>();
        }
    
        public int Id { get; set; }
        public string Comentario { get; set; }
        public string Titulo { get; set; }
        public int Adherentes_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoricoSet> HistoricoSets { get; set; }
        public virtual UsuarioSet UsuarioSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioSet> UsuarioSets { get; set; }
    }
}