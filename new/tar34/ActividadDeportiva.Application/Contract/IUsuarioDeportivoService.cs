using System;
using ActividadDeportiva.Application.Dtos.UsuarioDeportivo;

namespace ActividadDeportiva.Application.Contract
{
    public interface IUsuarioDeportivoService
    {
        Task<List<UsuarioDeportivoDto>> ObtenerTodos();
        Task<UsuarioDeportivoDto?> ObtenerPorId(int id);
        Task Crear(UsuarioDeportivoDto usuarioDto);
        Task Actualizar(UsuarioDeportivoDto usuarioDto);
        Task Eliminar(int id);
    }
}
