//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RelationalModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserva()
        {
            this.Estado = "Activa";
        }
    
        public System.DateTime Fecha { get; set; }
        public int Posicion { get; set; }
        public string Estado { get; set; }
        public int UsuarioId { get; set; }
        public int DocumentoIndex { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Documento Documento { get; set; }
    }
}
