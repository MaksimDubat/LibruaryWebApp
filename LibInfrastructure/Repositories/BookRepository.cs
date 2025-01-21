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
        public async Task<bool> ConfirmIssuanceAsync(int userId, int bookId, CancellationToken cancellation)
        {
            var cart = await _context.Cart
                .FirstOrDefaultAsync(x => x.UserId == userId && x.BookId == bookId && x.CartStatus == "Добавлено!", cancellation);
            var activeCart = await _context.Cart
                .CountAsync(x => x.UserId == userId && x.CartStatus == "Добавлено!", cancellation);
            return true;
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
            var issue = await ConfirmIssuanceAsync(userId, bookId, cancellation);
            var cart = new Cart
            {
                UserId = userId,
                BookId = bookId,
                Book = book,
                User = user,
                TakenAt = DateTime.UtcNow,
                StorageDays = 14,
                CartStatus = "Добавлено!"
            };
            await _context.Cart.AddAsync(cart, cancellation);
            return "Ok";
        }
        /// <inheritdoc/>
        public async Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookId == bookId, cancellation);
            const long maxSize = 5 * 1024 * 1024;
            var allowedType = new[] { ".jpg", ".jpeg", ".png" };
            var type = Path.GetExtension(image.FileName).ToLower();
            const int width = 300;
            const int height = 400;

            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream, cancellation);

            using var imageStream = new MemoryStream(memoryStream.ToArray());
            using var processedImage = await Image.LoadAsync(imageStream, cancellation);

            processedImage.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(width, height),
                Mode = ResizeMode.Stretch
            }));

            using var outputStream = new MemoryStream();
            IImageEncoder encoder = type == ".png" ? new PngEncoder() : new JpegEncoder();
            await processedImage.SaveAsync(outputStream, encoder, cancellation);
            var base64Image = Convert.ToBase64String(outputStream.ToArray());
            book.Image = base64Image;

            _context.Books.Update(book);
            return book;
        }
    }
}
