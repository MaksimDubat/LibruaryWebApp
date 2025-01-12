using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary>
    /// Запрос на пагинацию книг.
    /// </summary>
    public class GetBooksPagedQuery : IRequest<IEnumerable<Book>>
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
