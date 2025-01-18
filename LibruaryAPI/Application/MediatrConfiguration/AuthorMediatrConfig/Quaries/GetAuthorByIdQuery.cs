using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на получение автора по идентификатору.
    /// </summary>
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
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
