using LibruaryAPI.Application.Services;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;

namespace LibruaryAPI.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        /// <summary>
        /// Получение книги по ISBN.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="cancellation"></param>
        Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellation);
        /// <summary>
        /// Выдача книги.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <param name="cancellation"></param>
        Task<string> IssueAsync(int userId, int bookId, CancellationToken cancellation);
        /// <summary>
        /// Добавление фото.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="image"></param>
        /// <param name="cancellation"></param>
        Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation);
    }
   
}
