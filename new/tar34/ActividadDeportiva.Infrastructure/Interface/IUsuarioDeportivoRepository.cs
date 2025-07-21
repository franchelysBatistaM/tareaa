using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActividadDeportiva.Domain.Entities;

namespace ActividadDeportiva.Infrastructure.Interfaces
{
    public interface IUsuarioDeportivoRepository
    {
        Task<List<UsuarioDeportivo>> ObtenerTodosAsync();
        Task<UsuarioDeportivo?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(UsuarioDeportivo usuario);
        Task ActualizarAsync(UsuarioDeportivo usuario);
        Task EliminarAsync(UsuarioDeportivo usuario);
    }
}
