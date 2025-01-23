using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats;
using LibDomain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Microsoft.EntityFrameworkCore;

namespace LibApplication.Services
{
    /// <summary>
    /// Сервис по работе с изображением.
    /// </summary>
    public class ImageService : IImageService
    {
        private readonly MutableDbContext _context;
        public ImageService(MutableDbContext context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public async Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(x => x.BookId == bookId, cancellation);
            if (book == null)
            {
                throw new KeyNotFoundException();
            }
            const long maxSize = 5 * 1024 * 1024;
            if(image.Length > maxSize)
            {
                throw new InvalidOperationException();
            }
            var allowedType = new[] { ".jpg", ".jpeg", ".png" };
            var type = Path.GetExtension(image.FileName).ToLower();
            if (!allowedType.Contains(type))
            {
                throw new InvalidOperationException();
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
            return book;
        }
    }
}
