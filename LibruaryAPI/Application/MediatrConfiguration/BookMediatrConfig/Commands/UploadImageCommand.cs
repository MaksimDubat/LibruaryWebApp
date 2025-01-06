﻿using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Команда добавления изображения.
    /// </summary>
    public class UploadImageCommand : IRequest<Book>
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Файл изображения.
        /// </summary>
        public IFormFile Image { get; set; }
        public UploadImageCommand(int bookId, IFormFile image)
        {
            BookId = bookId;
            Image = image;
        }
    }
}
