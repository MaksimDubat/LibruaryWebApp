using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// Команда для обновления автора.
    /// </summary>
    public class UpdateAuthorCommand : IRequest<Author>
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Сущность автора.
        /// </summary>
        public Author Author { get; set; }
        public UpdateAuthorCommand(int id, Author author)
        {
            Id = id;
            Author = author;
        }
    }
}
