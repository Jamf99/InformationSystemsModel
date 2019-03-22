using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerParciales.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibreriaParciales;

namespace TallerParciales
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            CargarDatos(app.ApplicationServices);

        }

        private void CargarDatos(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {
                var ctx = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (ctx.Estudiante.Any())
                {
                    return;   // La base de datos ya tiene datos               
                }
                var estudiantes = new List<Estudiante> {
            new Estudiante { Nombre = "Hugo Chávez Frías", Email = "chavez@venezuela.com" },
            new Estudiante { Nombre = "Alvaro Uribe Vélez" , Email = "uribe@colombia.com"},
            new Estudiante { Nombre = "Juan Manuel Santos Calderón", Email = "santos@colombia.com" },
            new Estudiante { Nombre = "Rafael Correa Delgado", Email = "correo@ecuador.com" },
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
                estudiantes.ForEach(e => ctx.Estudiante.Add(e));
                ctx.SaveChanges();

                var materias = new List<Materia> {
            new Materia { Nombre = "Contabilidad y Costos", Creditos = 3 },
            new Materia { Nombre = "Electricidad y Magnetismo", Creditos = 4 },
            new Materia { Nombre = "Algorítmos y Estructuras de Datos", Creditos = 3 },
            new Materia { Nombre = "Ingeniería de Procesos", Creditos = 2 },
            new Materia { Nombre = "Electiva en CTS", Creditos = 5 },
            new Materia { Nombre = "Fundamentos de Mercadeo", Creditos = 2 },
            new Materia { Nombre = "Ingeniería Económica", Creditos = 3 },
            new Materia { Nombre = "Matemática Discreta", Creditos = 4 },
            new Materia { Nombre = "Modelado", Creditos = 2 },
            new Materia { Nombre = "Integrador I", Creditos = 3 }
        };
                materias.ForEach(m => ctx.Materia.Add(m));
                ctx.SaveChanges();

                var cursos = new List<Curso> {
            new Curso { AñoSem =161, Grupo = 1, Profesor = "Donald John trump", MateriaId = 1 },
            new Curso { AñoSem =162, Grupo = 1, Profesor = "Barack Hussein Obama", MateriaId = 2 },
            new Curso { AñoSem =162, Grupo = 1, Profesor = "Hillary Diane Rodham Clinton", MateriaId = 3 },
            new Curso { AñoSem =161, Grupo = 1, Profesor = "Mariano Rajoy Brey", MateriaId = 4 },
            new Curso { AñoSem =161, Grupo = 1, Profesor = "Verónica Michelle Bachelet Jeria", MateriaId = 5 },
        };
                cursos.ForEach(c => ctx.Curso.Add(c));
                ctx.SaveChanges();

                var parciales = new List<Parcial> {
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 25), Nota = 1.0, EstudianteId = 1, CursoId = 1, Porcentaje = 25 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 25), Nota = 3.5, EstudianteId = 2, CursoId = 1, Porcentaje = 20 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 25), Nota = 4.2, EstudianteId = 3, CursoId = 1, Porcentaje = 15 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 08, 18), Nota = 5.0, EstudianteId = 4, CursoId = 2, Porcentaje = 10 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 08, 18), Nota = 2.7, EstudianteId = 5, CursoId = 2, Porcentaje = 25 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 08, 18), Nota = 3.7, EstudianteId = 6, CursoId = 2, Porcentaje = 20 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 26), Nota = 3.8, EstudianteId = 7, CursoId = 3, Porcentaje = 30 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 26), Nota = 1.9, EstudianteId = 8, CursoId = 3, Porcentaje = 25 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 03, 26), Nota = 1.3, EstudianteId = 9, CursoId = 3, Porcentaje = 20 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 04, 01), Nota = 2.5, EstudianteId = 10, CursoId = 4, Porcentaje = 15 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 04, 01), Nota = 3.9, EstudianteId = 11, CursoId = 4, Porcentaje = 35 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 04, 01), Nota = 4.3, EstudianteId = 12, CursoId = 4, Porcentaje = 15 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 02, 28), Nota = 5.0, EstudianteId = 13, CursoId = 5, Porcentaje = 10 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 02, 28), Nota = 2.6, EstudianteId = 14, CursoId = 5, Porcentaje = 20 },
            new Parcial { Número = 1, Fecha = new DateTime(2016, 02, 28), Nota = 4.7, EstudianteId = 15, CursoId = 5, Porcentaje = 25 },
        };
                parciales.ForEach(p => ctx.Parcial.Add(p));
                ctx.SaveChanges();
            }
        }

    }
}
