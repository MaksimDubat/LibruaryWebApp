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
        /// Количество.
        /// </summary>
        public int Amount { get; set; }
        public UpdateBookCommand(int id, string title, string description, string image, int amount)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Amount = amount;
        }
    }
}
