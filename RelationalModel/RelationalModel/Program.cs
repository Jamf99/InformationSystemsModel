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
                Categoria cat = new Categoria();
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
                ctx.SaveChanges();
            }
        }
    }
}
