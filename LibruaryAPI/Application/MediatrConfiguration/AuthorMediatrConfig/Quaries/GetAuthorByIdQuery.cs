using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на получение автора по идентификатору.
    /// </summary>
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; } 
        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
