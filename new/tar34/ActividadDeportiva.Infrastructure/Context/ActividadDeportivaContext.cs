using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadDeportiva.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActividadDeportiva.Infrastructure.Context
{
    public class ActividadDeportivaContext : DbContext
    {
        public ActividadDeportivaContext(DbContextOptions<ActividadDeportivaContext> options) : base(options)
        {
        }

        public DbSet<UsuarioDeportivo> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UsuarioDeportivo>().HasData(
                new UsuarioDeportivo
                {
                    Id = 1,
                    Nombre = "Franchelys",
                    Apellido = "Batista",
                    Correo = "Franche.fit@gmail.com",
                    Telefono = "809-418-2018",
                    FechaNacimiento = new DateTime(1990, 5, 10),
                    PesoKg = 40,
                    AlturaCm = 160,
                    Genero = "Femenina"
                },
                new UsuarioDeportivo
                {
                    Id = 2,
                    Nombre = "Frankjerson",
                    Apellido = "Batista",
                    Correo = "Frank.entrenamiento@gmail.com",
                    Telefono = "829-999-6088",
                    FechaNacimiento = new DateTime(1988, 11, 2),
                    PesoKg = 78,
                    AlturaCm = 185,
                    Genero = "Masculino"
                }
            );
        }
    }
}
