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
    
    public partial class HistoricoSet
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int Reclamo_Id { get; set; }
        public int Estado_Id { get; set; }
        public int Area_Id { get; set; }
    
        public virtual AreaSet AreaSet { get; set; }
        public virtual EstadoSet EstadoSet { get; set; }
        public virtual ReclamoSet ReclamoSet { get; set; }
    }
}
