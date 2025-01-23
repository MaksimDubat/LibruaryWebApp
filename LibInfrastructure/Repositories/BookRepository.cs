using LibDomain.Common;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace LibruaryAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий по работе с книгами.
    /// </summary>
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly MutableDbContext _context;
        public BookRepository(MutableDbContext context) : base(context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public async Task<string> ConfirmIssuanceAsync(int userId, int bookId, CancellationToken cancellation)
        {
            var cart = await _context.Cart
                .FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId && x.CartStatus == CartStatus.InProgress, cancellation);
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookId == bookId && x.Amount > 0 ,cancellation);
            cart.CartStatus = CartStatus.Added;
            _context.Cart.Update(cart);
            book.Amount -= 1;
            _context.Books.Update(book);
            return "Book Confirmed";
        }
        /// <inheritdoc/>
        public async Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellation)
        {
            return await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ISBN == isbn, cancellation);
        }
        /// <inheritdoc/>
        public async Task<string> IssueAsync(int userId, int bookId, CancellationToken cancellation)
        {
            var user = await _context.AppUsers
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellation);
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookId == bookId, cancellation);
            var cart = new Cart
            {
                UserId = userId,
                BookId = bookId,
                Book = book,
                User = user,
                TakenAt = DateTime.UtcNow,
                StorageDays = 14,
                CartStatus = CartStatus.InProgress,
            };
            await _context.Cart.AddAsync(cart, cancellation);
            return "Book reserved";
        }
    }
}
