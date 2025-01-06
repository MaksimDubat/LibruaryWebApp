using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// МОдель команды для добавления книги.
    /// </summary>
    public class AddBookCommand : IRequest<Book>
    {
        /// <summary>
        /// Сущность книги.
        /// </summary>
        public Book Book { get; set; }
        public AddBookCommand (Book book)
        {
            Book = book;
        }
    }
}
