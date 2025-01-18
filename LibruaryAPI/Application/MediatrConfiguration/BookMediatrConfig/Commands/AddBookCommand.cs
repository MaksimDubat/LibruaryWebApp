using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды для добавления книги.
    /// </summary>
    public class AddBookCommand : IRequest<string>
    {
        public BookDto Book { get; set; }
        public AddBookCommand(BookDto book)
        {
            Book = book;
        }
    }
}
