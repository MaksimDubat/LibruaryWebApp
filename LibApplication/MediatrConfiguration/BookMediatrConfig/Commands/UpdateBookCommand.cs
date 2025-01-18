using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды для обновления пользователя.
    /// </summary>
    public class UpdateBookCommand : IRequest<string>
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Книга.
        /// </summary>
        public BookDto Book { get; set; }
        public UpdateBookCommand(int id, BookDto book)
        {
            Id = id;
            Book = book;
        }
    }
}
