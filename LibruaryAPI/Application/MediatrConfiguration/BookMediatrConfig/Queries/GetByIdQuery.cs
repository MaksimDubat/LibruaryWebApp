using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary>
    /// Получение книги по идентификатору.
    /// </summary>
    public class GetByIdQuery : IRequest<Book>
    {
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int Id { get; set; }
        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
