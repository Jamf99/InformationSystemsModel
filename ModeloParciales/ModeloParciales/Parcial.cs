//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModeloParciales
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parcial
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public int CursoGrupo { get; set; }
        public int CursoAñoSem { get; set; }
        public int CursoMateriaId { get; set; }
        public int EstudianteId { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
