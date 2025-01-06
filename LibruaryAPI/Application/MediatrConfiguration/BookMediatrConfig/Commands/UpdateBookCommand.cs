using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды для обновления пользователя.
    /// </summary>
    public class UpdateBookCommand : IRequest<Book>
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int Id { get; set; } 
        /// <summary>
        /// Сущность книги.
        /// </summary>
        public Book Book { get; set; }  
        public UpdateBookCommand(int id, Book book)
        {
            Id = id;
            Book = book;
        }
    }
}
