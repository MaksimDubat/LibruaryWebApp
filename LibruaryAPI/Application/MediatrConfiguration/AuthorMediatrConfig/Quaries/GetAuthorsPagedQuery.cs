using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на пагинацию.
    /// </summary>
    public class GetAuthorsPagedQuery : IRequest<IEnumerable<AuthorDto>>
    {
        /// <summary>
        /// Страница.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int PageSize { get; set; }

        public GetAuthorsPagedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
