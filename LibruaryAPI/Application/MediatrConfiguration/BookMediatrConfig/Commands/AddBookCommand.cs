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
        /// Название книги.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание книги.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Изображение.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }
        public AddBookCommand(string title, string description, string image, int authorId, int amount)
        {
            Title = title;
            Description = description;
            Image = image;
            AuthorId = authorId;
            Amount = amount;
        }
    }
}
