using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibruaryAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий по работе с CRUD-операциями и базовыми проверками.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MutableDbContext _context;
        public BaseRepository(MutableDbContext context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public async Task AddAsync(T entity, CancellationToken cancellation)
        {
            await _context.AddAsync(entity, cancellation);;
        }
        /// <inheritdoc/>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .AnyAsync(predicate, cancellation);
        }

        /// <inheritdoc/>
        public async Task<T> DeleteAsync(int id, CancellationToken cancellation)
        {
            var entity = await _context.Set<T>().FindAsync(id, cancellation);
            _context.Remove(entity);
            return entity;
        }
        /// <inheritdoc/>
        public Task<List<T>> GetAllAsync(CancellationToken cancellation)
        {
            var result = _context.Set<T>()
                .AsNoTracking()
                .ToListAsync(cancellation);
            return result;
        }
        /// <inheritdoc/>
        public async Task<T> GetAsync(int id, CancellationToken cancellation)
        {
            return await _context.Set<T>().FindAsync(id, cancellation);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellation)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Skip((pageNumber-1)* pageSize)
                .Take(pageSize)
                .ToListAsync(cancellation);
        }
        /// <inheritdoc/>
        public async Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            _context.Update(entity);
        } 
    }
}
