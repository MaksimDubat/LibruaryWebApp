using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// Команда для обновления автора.
    /// </summary>
    public class UpdateAuthorCommand : IRequest<string>
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Автор.
        /// </summary>
        public AuthorDto Author { get; set; }
        public UpdateAuthorCommand(int id, AuthorDto author)
        {
            Id = id;
            Author = author;
        }
    }
}
