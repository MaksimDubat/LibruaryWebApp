using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды добавления автора.
    /// </summary>
    public class AddAuthorCommand : IRequest<string>
    {
        /// <summary>
        /// Автор.
        /// </summary>
        public AuthorDto Author { get; set; }
        public AddAuthorCommand(AuthorDto author)
        {
            Author = author;
        }
    }
}
