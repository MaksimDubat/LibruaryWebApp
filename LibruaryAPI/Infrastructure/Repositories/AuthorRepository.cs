using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий по работе с авторами.
    /// </summary>
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly MutableDbContext _context;
        public AuthorRepository(MutableDbContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string firstName, string lastName, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .Include(x => x.Author)
                .Where(x => x.Author.FirstName == firstName && x.Author.LastName == lastName)
                .ToListAsync(cancellationToken);
            return books;
        }
    }

}
