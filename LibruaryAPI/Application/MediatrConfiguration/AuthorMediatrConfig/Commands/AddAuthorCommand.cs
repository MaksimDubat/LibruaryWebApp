using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// МОдель команды добавления автора.
    /// </summary>
    public class AddAuthorCommand : IRequest<Author>
    {
        /// <summary>
        /// Сущность автора.
        /// </summary>
        public Author Author { get; set; }
        public AddAuthorCommand(Author author) 
        { 
            Author = author; 
        }
    }
}
