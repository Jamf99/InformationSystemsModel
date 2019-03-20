using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial
{
    class Program
    {

        public static void CargaDatos(Contexto ctx)
        {
            var estudiantes = new List<Estudiante> {
        new Estudiante { Nombre = "Hugo Chávez Frías", Email = "Chavez@venezuela.com" },
        new Estudiante { Nombre = "Alvaro Uribe Vélez" , Email = "Uribe@colombia.com"},
        new Estudiante { Nombre = "Juan Manuel Santos Calderón", Email = "santos@colombia.com" },
        new Estudiante { Nombre = "Rafael Correa Delgado", Email = "Correa@ecuador.com" },
        new Estudiante { Nombre = "Juan Evo Morales Ayma", Email = "Evo@bolivia.com" },
        new Estudiante { Nombre = "Nicolás Maduro Moros", Email = "Maduro@venezuela.com" },
        new Estudiante { Nombre = "Ollanta Humala Tasso", Email = "Ollanta@peru.com" },
        new Estudiante { Nombre = "Ricardo Martinelli", Email = "Martinelli@panama.com" },
        new Estudiante { Nombre = "José Alberto Mujica Cordano", Email = "Mujica@uruguay.com" },
        new Estudiante { Nombre = "Luis Federico Franco Gómez", Email = "Franco@paraguay.com" },
        new Estudiante { Nombre = "Miguel Sebastián Piñera", Email = "Piñera@chile.com" },
        new Estudiante { Nombre = "Luis Ignacio Lula Da Silva", Email = "Lula@brasil.com" },
        new Estudiante { Nombre = "Dilma Vana Roussett", Email = "Roussett@brasil.com" },
        new Estudiante { Nombre = "Cristina Fernández de Kirchner", Email = "Kirchner@argentina.com" },
        new Estudiante { Nombre = "Pedro Pablo Kuczynski", Email = "Kuczynski@peru.com" }
    };
            estudiantes.ForEach(e => ctx.Estudiantes.Add(e));
            ctx.SaveChanges();

            var materias = new List<Materia> {
        new Materia { Nombre = "Contabilidad y Costos" },
        new Materia { Nombre = "Electricidad y Magnetismo" },
        new Materia { Nombre = "Algorítmos y Estructuras de Datos" },
        new Materia { Nombre = "Ingeniería de Procesos" },
        new Materia { Nombre = "Electiva en CTS" },
        new Materia { Nombre = "Fundamentos de Mercadeo" },
        new Materia { Nombre = "Ingeniería Económica" },
        new Materia { Nombre = "Matemática Discreta" },
        new Materia { Nombre = "Modelado" },
        new Materia { Nombre = "Integrador I" }
    };
            materias.ForEach(m => ctx.Materias.Add(m));
            ctx.SaveChanges();

            var cursos = new List<Curso> {
        new Curso { AñoSem =161, Grupo = 1, MateriaId = 1 },
        new Curso { AñoSem =162, Grupo = 1, MateriaId = 1 },
        new Curso { AñoSem =162, Grupo = 1, MateriaId = 2 },
        new Curso { AñoSem =162, Grupo = 1, MateriaId = 3 },
        new Curso { AñoSem =161, Grupo = 1, MateriaId = 4 },
        new Curso { AñoSem =161, Grupo = 1, MateriaId = 5 },
    };
            cursos.ForEach(c => ctx.Cursos.Add(c));
            ctx.SaveChanges();

            var parciales = new List<Parcial> {
        new Parcial { Número = 1, Nota = 1.0, EstudianteId = 1, CursoMateriaId = 1, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 3.5, EstudianteId = 2, CursoMateriaId = 1, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 4.2, EstudianteId = 3, CursoMateriaId = 1, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 5.0, EstudianteId = 4, CursoMateriaId = 2, CursoGrupo = 1, CursoAñoSem = 162 },
        new Parcial { Número = 1, Nota = 2.7, EstudianteId = 5, CursoMateriaId = 2, CursoGrupo = 1, CursoAñoSem = 162 },
        new Parcial { Número = 1, Nota = 3.7, EstudianteId = 6, CursoMateriaId = 2, CursoGrupo = 1, CursoAñoSem = 162 },
        new Parcial { Número = 1, Nota = 3.8, EstudianteId = 7, CursoMateriaId = 3, CursoGrupo = 1, CursoAñoSem = 162 },
        new Parcial { Número = 1, Nota = 1.9, EstudianteId = 8, CursoMateriaId = 3, CursoGrupo = 1, CursoAñoSem = 162 },
        new Parcial { Número = 1, Nota = 1.3, EstudianteId = 9, CursoMateriaId = 4, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 2.5, EstudianteId = 10, CursoMateriaId = 4, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 3.9, EstudianteId = 11, CursoMateriaId = 4, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 4.3, EstudianteId = 12, CursoMateriaId = 5, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 5.0, EstudianteId = 13, CursoMateriaId = 5, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 2.6, EstudianteId = 14, CursoMateriaId = 5, CursoGrupo = 1, CursoAñoSem = 161 },
        new Parcial { Número = 1, Nota = 4.7, EstudianteId = 15, CursoMateriaId = 5, CursoGrupo = 1, CursoAñoSem = 161 }
    };
            parciales.ForEach(p => ctx.Parciales.Add(p));
            ctx.SaveChanges();
        }


        static void Main(string[] args)
        {
            using(var ctx = new Contexto())
            {
                CargaDatos(ctx);
            }
        }
    }
}
