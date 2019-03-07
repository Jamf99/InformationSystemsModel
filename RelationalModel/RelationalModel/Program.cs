using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Contexto())
            {
                /*Usuario usu = new Usuario();
                usu.Id = 12203001;
                usu.Nombre = "Hugo Chávez";
                usu.Plan = "Industrial";
                usu.Email = "chavez@venezuela.com";
                ctx.Usuarios.Add(usu);
                ctx.SaveChanges();
                */
                /*Categoria cat = new Categoria();
                cat.Id = 1;
                cat.Nombre = "General";
                cat.DiasPrestamo = 1;
                cat.MultaDia = 2000;

                Documento doc = new Documento();
                doc.Index = 1;
                doc.Titulo = "Sistemas de Información";
                doc.Tipo = "Libro";
                doc.Categoria = cat;
                ctx.Documentos.Add(doc);
                ctx.SaveChanges();*/

                //Recorre los documentos de las categorias
               /* foreach (var c in ctx.Categorias) {
                    foreach (var d in c.Documentos) {
                        Console.WriteLine("{0} {1}", d.Index, d.Titulo);
                    }
                }*/

                //actualizar una entidad
                /*var cat = ctx.Categorias.First(c => c.Id == 1);
                cat.MultaDia = 3000;
                ctx.SaveChanges();*/

                //Agrega una reserva a un usuario y un documento
                /*var res = new Reserva();
                res.Fecha = "Sabado 3 de Marzo";
                res.Posicion = "Activa";
                res.UsuarioId = 12203001;
                res.DocumentoIndex = 1;
                ctx.Reservas.Add(res);
                ctx.SaveChanges();*/
            }
        }
    }
}
