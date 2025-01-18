using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibruaryAPI.Infrastructure.UnityOfWork
{
    /// <summary>
    /// Реализация паттерна Unit of Work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MutableDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }
        public UnitOfWork(MutableDbContext context, IServiceProvider serviceProvider, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            Books = bookRepository;
            Authors = authorRepository;
        }
        /// <inheritdoc/>
        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            return ActivatorUtilities.CreateInstance<BaseRepository<T>>(_serviceProvider, _context);
        }
        /// <inheritdoc/>
        public async Task<int> CompleteAsync(CancellationToken cancellation)
        {
            return await _context.SaveChangesAsync(cancellation);
        }
        /// <inheritdoc/>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
