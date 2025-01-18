using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            await _context.AddAsync(entity, cancellation);;
        }
        /// <inheritdoc/>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation)
        {
            return await _context.Set<T>().AnyAsync(predicate, cancellation);
        }

        /// <inheritdoc/>
        public async Task<T> DeleteAsync(int id, CancellationToken cancellation)
        {
            var entity = await _context.Set<T>().FindAsync(id, cancellation);
            if (entity == null)
            {
                throw new KeyNotFoundException(nameof(entity));
            }
            _context.Remove(entity);
            return entity;
        }
        /// <inheritdoc/>
        public Task<List<T>> GetAllAsync(CancellationToken cancellation)
        {
            var result = _context.Set<T>().ToListAsync(cancellation);
            if(result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;
        }
        /// <inheritdoc/>
        public async Task<T> GetAsync(int id, CancellationToken cancellation)
        {
            var entity = await _context.Set<T>().FindAsync(id, cancellation);
            if (entity == null)
            {
                throw new KeyNotFoundException(nameof(entity));
            }
            return entity;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellation)
        {
            if(pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentException("wrong page size");
            }
            return await _context.Set<T>()
                .Skip((pageNumber-1)* pageSize)
                .Take(pageSize)
                .ToListAsync(cancellation);
        }
        /// <inheritdoc/>
        public async Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Update(entity);
        } 
    }
}
