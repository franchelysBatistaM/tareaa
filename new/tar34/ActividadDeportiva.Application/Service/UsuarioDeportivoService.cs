using ActividadDeportiva.Application.Contract;
using ActividadDeportiva.Application.Dtos.UsuarioDeportivo;
using ActividadDeportiva.Domain.Entities;
using ActividadDeportiva.Infrastructure.Interfaces;

namespace ActividadDeportiva.Application.Service
{
    public class UsuarioDeportivoService : IUsuarioDeportivoService
    {
        private readonly IUsuarioDeportivoRepository _repository;

        public UsuarioDeportivoService(IUsuarioDeportivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UsuarioDeportivoDto>> ObtenerTodos()
        {
            var usuarios = await _repository.ObtenerTodosAsync();
            return usuarios.Select(MapToDto).ToList();
        }

        public async Task<UsuarioDeportivoDto?> ObtenerPorId(int id)
        {
            var usuario = await _repository.ObtenerPorIdAsync(id);
            return usuario is null ? null : MapToDto(usuario);
        }

        public async Task Crear(UsuarioDeportivoDto usuarioDto)
        {
            Validar(usuarioDto);
            var entity = MapToEntity(usuarioDto);
            entity.Id = 0;
            await _repository.AgregarAsync(entity);
        }

        public async Task Actualizar(UsuarioDeportivoDto usuarioDto)
        {
            Validar(usuarioDto);
            await _repository.ActualizarAsync(MapToEntity(usuarioDto));
        }

        public async Task Eliminar(int id)
        {
            var usuario = await _repository.ObtenerPorIdAsync(id);
            if (usuario is not null)
            {
                await _repository.EliminarAsync(usuario);
            }
        }

        private static UsuarioDeportivoDto MapToDto(UsuarioDeportivo entity) => new()
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Apellido = entity.Apellido,
            Correo = entity.Correo,
            Telefono = entity.Telefono,
            FechaNacimiento = entity.FechaNacimiento,
            PesoKg = entity.PesoKg,
            AlturaCm = entity.AlturaCm,
            Genero = entity.Genero
        };

        private static UsuarioDeportivo MapToEntity(UsuarioDeportivoDto dto)
        {
            var entity = new UsuarioDeportivo
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Telefono = dto.Telefono,
                FechaNacimiento = dto.FechaNacimiento,
                PesoKg = dto.PesoKg,
                AlturaCm = dto.AlturaCm,
                Genero = dto.Genero
            };

            if (dto.Id > 0)
                entity.Id = dto.Id;

            return entity;
        }

        private void Validar(UsuarioDeportivoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new ArgumentException("El apellido es obligatorio.");
            if (dto.PesoKg <= 0) throw new ArgumentException("El peso debe ser mayor a 0.");
            if (dto.AlturaCm <= 0) throw new ArgumentException("La altura debe ser mayor a 0.");
            if (dto.FechaNacimiento >= DateTime.Today) throw new ArgumentException("La fecha de nacimiento debe ser en el pasado.");
        }
    }
}
