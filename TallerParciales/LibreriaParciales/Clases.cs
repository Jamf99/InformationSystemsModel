using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaParciales
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            this.Parciales = new HashSet<Parcial>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite el nombre del Estudiante"), MaxLength(50)]
        public string Nombre { get; set; }
        [Required, Display(Name = "Correo Electrónico"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Parcial> Parciales { get; set; }
    }

    public partial class Materia
    {
        public Materia()
        {
            this.Cursos = new HashSet<Curso>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe digitar el nombre de la Materia"), MaxLength(50)]
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }

    public partial class Curso
    {
        public Curso()
        {
            this.Parciales = new HashSet<Parcial>();
        }
        public int Id { get; set; }
        public int Grupo { get; set; }
        [Display(Name = "Año y semestre (ej. 162)")]
        public int AñoSem { get; set; }
        [Required(ErrorMessage = "Debe digitar el nombre del Profesor"), MaxLength(50)]
        public string Profesor { get; set; }
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual ICollection<Parcial> Parciales { get; set; }
    }

    public partial class Parcial
    {
        public int Id { get; set; }
        public int Número { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }
        [Range(0.0, 5.0)]
        public double Nota { get; set; }
        public double Porcentaje { get; set; }
        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Curso Curso { get; set; }
    }

}
