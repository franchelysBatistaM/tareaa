using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActividadDeportiva.Infrastructure.Core
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> ObtenerTodosAsync() =>
            await _dbSet.ToListAsync();

        public async Task<T?> ObtenerPorIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task AgregarAsync(T entidad)
        {
            _dbSet.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(T entidad)
        {
            _dbSet.Update(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(T entidad)
        {
            _dbSet.Remove(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
