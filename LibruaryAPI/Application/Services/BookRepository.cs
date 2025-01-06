using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace LibruaryAPI.Application.Services
{
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
            if (cart != null)
            {
                return false;
            }
            var activeCart = await _context.Cart
                .CountAsync(x => x.UserId == userId && x.CartStatus == "Добавлено!", cancellation);
            if (activeCart >= 5)
            {
                return false;
            }
            return true;
        }
        /// <inheritdoc/>
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
        /// <inheritdoc/>
        public async Task<string> IssueAsync(int userId, int bookId, CancellationToken cancellation)
        {
            var user = await _context.AppUsers
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellation);
            if (user == null)
            {
                throw new ArgumentException("not found");
            }
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookId == bookId, cancellation);
            if (book == null)
            {
                throw new ArgumentException("not found");
            }
            if (!book.IsAvaiable)
            {
                return "Not available";
            }
            var issue = await ConfirmIssuanceAsync(userId, bookId, cancellation);
            if (!issue)
            {
                return "Not avaiable";
            }
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
            await _context.Cart.AddAsync(cart,cancellation);
            await _context.SaveChangesAsync(cancellation);
            return "Ok";
        }
        /// <inheritdoc/>
        public async Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync( x => x.BookId == bookId, cancellation);
            if (book == null)
            {
                throw new ArgumentException("invalid");
            }
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("invalid");
            }
            const long maxSize = 5 * 1024* 1024;    
            if(image.Length > maxSize)
            {
                throw new ArgumentException("invalid size");
            }
            var allowedType = new[] {".jpg", ".jpeg", ".png"};
            var type = Path.GetExtension(image.FileName).ToLower();
            if (!allowedType.Contains(type))
            {
                throw new ArgumentException("invalid type");
            }
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
            await _context.SaveChangesAsync(cancellation);
            return book;
        }
    }
}
