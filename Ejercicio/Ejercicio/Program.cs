using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio
{
    class Program
    {



        static void Main(string[] args)
        {
            using (var contexto = new Contexto())
            {
                // Adiciona un estudiante con dos materias
                var est = new Estudiante { NomEst = "Juan" };
                var mat1 = new Materia { NomMat = "Algebra" };
                var mat2 = new Materia { NomMat = "Fisica" };
                est.Materias.Add(mat1);
                est.Materias.Add(mat2);
                contexto.Estudiantes.Add(est);

                // Adiciona una materia por estudiante
                var est1 = new Estudiante { NomEst = "Pedro" };
                var est2 = new Estudiante { NomEst = "Pablo" };
                var mat3 = new Materia { NomMat = "Organizaciones" };
                est1.Materias.Add(mat3);
                est2.Materias.Add(mat3);
                contexto.Estudiantes.Add(est1);
                contexto.Estudiantes.Add(est2);
                contexto.Materias.Add(mat3);
                contexto.SaveChanges();

                // Consulta los estudiantes y sus materias
                Console.WriteLine("Estudiantes y sus materias");
                var estes = contexto.Estudiantes;
                foreach (var e in estes)
                {
                    Console.WriteLine("{0} {1}", e.CodEst, e.NomEst);
                    foreach (var m in e.Materias)
                        Console.WriteLine("\t{0}", m.NomMat);
                }

                // Consulta las materias y sus estudiantes
                Console.WriteLine("\nMaterias y sus estudiantes");
                var mtras = contexto.Materias;
                foreach (var m in mtras)
                {
                    Console.WriteLine("{0}", m.NomMat);
                    foreach (var e in m.Estudiantes)
                        Console.WriteLine("\t{0} ", e.NomEst);
                }
            }

        }
    }
}
