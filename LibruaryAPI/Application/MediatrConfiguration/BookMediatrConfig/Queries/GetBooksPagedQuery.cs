using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary>
    /// Запрос на пагинацию книг.
    /// </summary>
    public class GetBooksPagedQuery : IRequest<IEnumerable<BookDto>>
    {
        /// <summary>
        /// Страница.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Количество элементов.
        /// </summary>
        public int PageSize { get; set; }

        public GetBooksPagedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
