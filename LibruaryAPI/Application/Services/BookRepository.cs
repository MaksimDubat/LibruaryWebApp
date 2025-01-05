using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Application.Services
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly MutableDbContext _context;
        public BookRepository(MutableDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellation)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException(nameof(isbn));
            }
            var book = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == isbn, cancellation);
            if (book == null)
            {
                throw new ArgumentException("Not found");
            }
            return book;
        }

        public Task<string> IssueAsync(int userId, int bookId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
