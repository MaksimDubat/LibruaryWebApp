﻿using LibruaryAPI.Application.Interfaces;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий по работе с CRUD-операциями.
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
            await _context.AddAsync(entity, cancellation);
            await _context.SaveChangesAsync(cancellation);
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
            await _context.SaveChangesAsync(cancellation);
            return entity;
        }
        /// <inheritdoc/>
        public Task<List<T>> GetAllAsync(CancellationToken cancellation)
        {
            return _context.Set<T>().ToListAsync(cancellation);
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
        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            if(pageNumber < 1 || pageSize < 1)
            {
                throw new ArgumentException("wrong page size");
            }
            return await _context.Set<T>()
                .Skip((pageNumber-1)* pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public async Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
