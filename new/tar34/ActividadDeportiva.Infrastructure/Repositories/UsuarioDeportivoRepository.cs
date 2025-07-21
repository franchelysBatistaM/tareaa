using ActividadDeportiva.Domain.Entities;
using ActividadDeportiva.Infrastructure.Context;
using ActividadDeportiva.Infrastructure.Core;
using ActividadDeportiva.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ActividadDeportiva.Infrastructure.Repositories
{
    public class UsuarioDeportivoRepository : BaseRepository<UsuarioDeportivo>, IUsuarioDeportivoRepository
    {
        public UsuarioDeportivoRepository(ActividadDeportivaContext context)
            : base(context)
        {
        }
    }
}
