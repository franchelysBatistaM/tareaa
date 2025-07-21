using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadDeportiva.Application.Core
{
    public interface IBaseService<TDto>
    {
        Task<List<TDto>> ObtenerTodosAsync();
        Task<TDto?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(TDto dto);
        Task ActualizarAsync(TDto dto);
        Task EliminarAsync(int id);
    }

}
