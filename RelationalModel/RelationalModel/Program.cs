using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationalModel
{
    class Program
    {

        public static void CargaDatos(Contexto ctx)
        {
            var usuarios = new List<Usuario> {
        new Usuario { Id = 1, Nombre = "Hugo Chavez Frias", Plan = "Sistemas", Email = "chavez@venezuela.com" },
        new Usuario { Id = 2, Nombre = "Alvaro Uribe Velez", Plan = "Telemática", Email = "uribe@colombia.com" },
        new Usuario { Id = 3, Nombre = "Juan Manuel Santos Calderón", Plan = "Industrial", Email = "santos@colombia.com" },
        new Usuario { Id = 4, Nombre = "Rafael Correa Delgado", Plan = "Industrial", Email = "correa@ecudador.com" },
        new Usuario { Id = 5, Nombre = "Juan Evo Morales Ayma", Plan = "DMI", Email = "evo@bolivia.com" },
        new Usuario { Id = 6, Nombre = "Nicolás Maduro Moros", Plan = "DMI", Email = "maduro@venezuela.com" },
        new Usuario { Id = 7, Nombre = "Ollanta Humala Tasso", Plan = "Telemática", Email = "ollanta@peru.com" },
        new Usuario { Id = 8, Nombre = "Ricardo Martinelli", Plan = "Sistemas", Email = "martinelli@panama.com" }
    };
            usuarios.ForEach(u => ctx.Usuarios.Add(u));

            var categorias = new List<Categoria> {
        new Categoria { Id = 1, Nombre = "Referencia", DiasPrestamo = 0, MultaDia = 0 },
        new Categoria { Id = 2, Nombre = "Reserva", DiasPrestamo = 1, MultaDia = 3000m },
        new Categoria { Id = 3, Nombre = "General", DiasPrestamo = 8, MultaDia = 2000m },
    };
            categorias.ForEach(c => ctx.Categorias.Add(c));

            var autores = new List<Autor> {
        new Autor { Id = 1, Nombre = "José Alberto Mujica Cordano" },
        new Autor { Id = 2, Nombre = "Luis Federico Franco Gomez" },
        new Autor { Id = 3, Nombre = "Miguel Sebastián Piñera" },
        new Autor { Id = 4, Nombre = "Luis Ignacio Lula Da Silva" },
        new Autor { Id = 5, Nombre = "Dilma Vana Roussett" }
    };
            autores.ForEach(a => ctx.Autores.Add(a));

            var documentos = new List<Documento> {
        new Documento { Index = 1050, CategoriaId = 1, Titulo = "Algoritmos", Tipo = "Libro" },
        new Documento { Index = 4022, CategoriaId = 2, Titulo = "Electricidad", Tipo = "Lectura" },
        new Documento { Index = 3141, CategoriaId = 3, Titulo = "Cálculo", Tipo = "Libro" },
        new Documento { Index = 2021, CategoriaId = 1, Titulo = "Inglés", Tipo = "Congreso" },
        new Documento { Index = 2042, CategoriaId = 2, Titulo = "Francés", Tipo = "Caso" }
    };
            documentos.ForEach(d => ctx.Documentos.Add(d));

            var reservas = new List<Reserva> {
       new Reserva { Fecha = new DateTime(2016, 11, 01), Posicion = 1, Estado = "Activa", UsuarioId = 7, DocumentoIndex = 1050 },
        new Reserva { Fecha = new DateTime(2016, 12, 25), Posicion = 2, Estado = "Cancelada", UsuarioId = 1, DocumentoIndex = 4022 },
        new Reserva { Fecha = new DateTime(2016, 01, 13), Posicion = 5, Estado = "Activa", UsuarioId = 3, DocumentoIndex = 1050 },
        new Reserva { Fecha = new DateTime(2016, 06, 21), Posicion = 3, Estado = "Activa", UsuarioId = 2, DocumentoIndex = 3141 },
        new Reserva { Fecha = new DateTime(2016, 09, 22), Posicion = 1, Estado = "Cancelada", UsuarioId = 1, DocumentoIndex = 2021 }
    };
            reservas.ForEach(r => ctx.Reservas.Add(r));


            var autorias = new List<Autoria> {
        new Autoria { AutorId = 1, DocumentoIndex = 1050, Rol = "Principal" },
        new Autoria { AutorId = 2, DocumentoIndex = 4022, Rol = "Principal" },
        new Autoria { AutorId = 3, DocumentoIndex = 3141, Rol = "Principal" },
        new Autoria { AutorId = 4, DocumentoIndex = 2021, Rol = "Principal" },
        new Autoria { AutorId = 5, DocumentoIndex = 2042, Rol = "Principal" },
    };
            autorias.ForEach(a => ctx.Autorias.Add(a));

            var ejemplares = new List<Ejemplar> {
        new Ejemplar { DocumentoIndex = 1050, CodBarras = 1, Numero = 1, Estado = "Prestado" },
        new Ejemplar { DocumentoIndex = 4022, CodBarras = 2, Numero = 1, Estado = "Prestado" },
        new Ejemplar { DocumentoIndex = 3141, CodBarras = 3, Numero = 1, Estado = "Prestado" },
        new Ejemplar { DocumentoIndex = 2021, CodBarras = 4, Numero = 1, Estado = "Disponible" },
        new Ejemplar { DocumentoIndex = 2042, CodBarras = 5, Numero = 1, Estado = "Disponible" }
    };
            ejemplares.ForEach(e => ctx.Ejemplares.Add(e));

            var prestamos = new List<Prestamo> {
        new Prestamo { Fecha = new DateTime(2016, 10, 01), Id = 5, UsuarioId = 2 },
        new Prestamo { Fecha = new DateTime(2016, 11, 25), Id = 4, UsuarioId = 1 },
        new Prestamo { Fecha = new DateTime(2016, 10, 13), Id = 3, UsuarioId = 3 },
        new Prestamo { Fecha = new DateTime(2016, 10, 21), Id = 2, UsuarioId = 1 },
        new Prestamo { Fecha = new DateTime(2016, 09, 22), Id = 1, UsuarioId = 2 }
    };
            prestamos.ForEach(p => ctx.Prestamos.Add(p));

            var detalles = new List<Detalle> {
        new Detalle { FechaDev = new DateTime(2010, 11, 01), EjemplarCodBarras = 1, PrestamoId = 1 },
        new Detalle { FechaDev = new DateTime(2010, 12, 25), EjemplarCodBarras = 1, PrestamoId = 2 },
        new Detalle { FechaDev = new DateTime(2010, 01, 13), EjemplarCodBarras = 1, PrestamoId = 3 },
        new Detalle { FechaDev = new DateTime(2010, 06, 21), EjemplarCodBarras = 1, PrestamoId = 4 },
        new Detalle { FechaDev = new DateTime(2010, 09, 22), EjemplarCodBarras = 1, PrestamoId = 5 },
        new Detalle { FechaDev = new DateTime(2010, 11, 01), EjemplarCodBarras = 2, PrestamoId = 1 },
        new Detalle { FechaDev = new DateTime(2010, 12, 25), EjemplarCodBarras = 2, PrestamoId = 2 },
        new Detalle { FechaDev = new DateTime(2010, 01, 13), EjemplarCodBarras = 2, PrestamoId = 3 },
        new Detalle { FechaDev = new DateTime(2010, 06, 21), EjemplarCodBarras = 2, PrestamoId = 4 },
        new Detalle { FechaDev = new DateTime(2010, 09, 22), EjemplarCodBarras = 2, PrestamoId = 5 },
        new Detalle { FechaDev = new DateTime(2010, 11, 01), EjemplarCodBarras = 3, PrestamoId = 1 },
        new Detalle { FechaDev = new DateTime(2010, 12, 25), EjemplarCodBarras = 3, PrestamoId = 2 },
        new Detalle { FechaDev = new DateTime(2010, 01, 13), EjemplarCodBarras = 3, PrestamoId = 3 },
        new Detalle { FechaDev = new DateTime(2010, 06, 21), EjemplarCodBarras = 3, PrestamoId = 4 },
        new Detalle { FechaDev = new DateTime(2010, 09, 22), EjemplarCodBarras = 3, PrestamoId = 5 }
            };
            detalles.ForEach(d => ctx.Detalles.Add(d));

            var multas = new List<Multa> {
        new Multa { FechaCanc = new DateTime(2016, 10, 01), Valor = 1000, Id = 1 },
        new Multa { FechaCanc = new DateTime(2016, 10, 25), Valor = 10000, Id = 2 },
        new Multa { FechaCanc = new DateTime(2016, 09, 13), Valor = 3000, Id = 3 },
        new Multa { FechaCanc = new DateTime(2016, 09, 21), Valor = 20000, Id = 4 },
        new Multa { FechaCanc = new DateTime(2016, 09, 22), Valor = 2000, Id = 5 },
        new Multa { FechaCanc = new DateTime(2016, 10, 01), Valor = 2000, Id = 6 },
        new Multa { FechaCanc = new DateTime(2016, 10, 25), Valor = 6000, Id = 7 },
        new Multa { FechaCanc = new DateTime(2016, 10, 13), Valor = 5000, Id = 8 },
    };
            multas[0].Detalles = detalles[0];
            multas[1].Detalles = detalles[3];
            multas[2].Detalles = detalles[4];
            multas[3].Detalles = detalles[6];
            multas[4].Detalles = detalles[8];
            multas[5].Detalles = detalles[10];
            multas[6].Detalles = detalles[12];
            multas[7].Detalles = detalles[13];
            multas.ForEach(m => ctx.Multas.Add(m));
            ctx.SaveChanges();
        }

        //Para todas las categorías nombre de la categoría y número total de multas aplicadas a ejemplares de esa categoría. 
        public static void ejercicio1(Contexto ctx)
        {
            ctx.Multas.GroupBy(x => x.Detalles.Ejemplar.Documento.Categoria.Nombre).ToList().ForEach(x => Console.WriteLine(x.Key + "--" + x.Count()));
        }

        //Categoría con mayor número de multas
        public static void ejercicio2(Contexto ctx)
        {
            Console.WriteLine(ctx.Multas.GroupBy(x => x.Detalles.Ejemplar.Documento.Categoria.Nombre).OrderByDescending(x => x.Count()).First().Key);
        }

        //Para todos los documentos título del documento y valor total en multas. 
        public static void ejercicio3(Contexto ctx)
        {
            ctx.Multas.GroupBy(
                x => x.Detalles.Ejemplar.Documento.Titulo).Select(
                x => new {
                    titulo = x.Key, multa = x.Select(y => y.Valor).Sum()
                }).ToList().ForEach(x => Console.WriteLine(x.titulo + "--" + x.multa));
        }

        //Para todos los documentos título y número total de reservas.
        public static void ejercicio4(Contexto ctx)
        {
            ctx.Documentos.ToList().ForEach(x => Console.WriteLine("Documento: " + x.Titulo + ", Número de Reservas: " + x.Reservas.Count()));
        }

        //Para todos los autores nombre y todas las reservas con fecha, estado y posición, de sus documentos. 
        public static void ejercicio5(Contexto ctx)
        {
            ctx.Autores.ToList().ForEach(x => 
            {
                Console.WriteLine("Autor: " + x.Nombre);
                Console.WriteLine("Reservas: ");
                x.Autorias.ToList().ForEach(y => y.Documento.Reservas.ToList().ForEach( z => Console.WriteLine("Fecha: " + z.Fecha + "Estado: " + z.Estado + "Posición: " + z.Posicion)));
            });
        }

        //Títulos de los documentos reservados por el usuario id 
        public static void ejercicio6(Contexto ctx)
        {
            ctx.Usuarios.Where(x => x.Id == 2).First().Reservas.Select(x => x.Documento.Titulo).ToList().ForEach(x => Console.WriteLine(x));
        }

        //Autores de los documentos prestados por el usuario
        public static void ejercicio7(Contexto ctx)
        {
            ctx.Detalles.Where(d => d.Prestamo.Usuario.Id == 2).SelectMany(d => d.Ejemplar.Documento.Autorias).Distinct().ToList().ForEach(r => Console.WriteLine(r.Autor.Nombre));
        }

       //Para cada usuario nombre del usuario y lista de nombres de los autores de los documentos que ha prestado.
        public static void ejercicio8(Contexto ctx)
        {
            ctx.Usuarios.ToList().Where(s => s.Prestamos.Count != 0).ToList().ForEach(x =>
            {
                Console.WriteLine(x.Nombre);
                Console.WriteLine("Autores Libros Prestados");
                x.Prestamos.ToList().ForEach(y => y.Detalles.ToList().ForEach(z => z.Ejemplar.Documento.Autorias.ToList()
                .ForEach( w => Console.WriteLine("         Autor: "+w.Autor.Nombre))));
            });
        }

        static void Main(string[] args)
        {
            using (var ctx = new Contexto())
            {
                /*ejercicio1(ctx);
                ejercicio2(ctx);
                ejercicio3(ctx);
                ejercicio4(ctx);
                ejercicio5(ctx);
                ejercicio6(ctx);
                ejercicio7(ctx);*/
               // ejercicio7(ctx);

            }
        }
    }
}
