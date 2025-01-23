using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Interfaces
{
    /// <summary>
    /// Интерфейс по работе с изображением.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Добавление фото.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="image"></param>
        /// <param name="cancellation"></param>
        Task<Book> UploadImageAsync(int bookId, IFormFile image, CancellationToken cancellation);
    }
}
