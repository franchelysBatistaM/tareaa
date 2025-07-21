using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadDeportiva.Domain.Core;

namespace ActividadDeportiva.Domain.Entities
{
    public class UsuarioDeportivo : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double PesoKg { get; set; }
        public double AlturaCm { get; set; }
        public string? Genero { get; set; }
    }
}
