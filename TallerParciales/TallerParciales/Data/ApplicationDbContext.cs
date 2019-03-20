using System;
using System.Collections.Generic;
using System.Text;
using LibreriaParciales;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TallerParciales.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Estudiante>().HasAlternateKey(e => e.Email);
            builder.Entity<Curso>().HasAlternateKey(c => new { c.MateriaId, c.AñoSem, c.Grupo });
            builder.Entity<Parcial>().HasAlternateKey(p => new { p.EstudianteId, p.CursoId, p.Número });
        }
        public DbSet<LibreriaParciales.Estudiante> Estudiante { get; set; }
        public DbSet<LibreriaParciales.Parcial> Parcial { get; set; }
        public DbSet<LibreriaParciales.Curso> Curso { get; set; }
        public DbSet<LibreriaParciales.Materia> Materia { get; set; }

    }


}
