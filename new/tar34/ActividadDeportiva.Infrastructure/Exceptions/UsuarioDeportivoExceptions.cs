using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadDeportiva.Infrastructure.Exceptions
{
    public class UsuarioDeportivoNotFoundException : Exception
    {
        public UsuarioDeportivoNotFoundException(int id)
            : base($"El usuario deportivo con ID {id} no fue encontrado.")
        {
        }
    }
}
