using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries
{
    /// <summary>
    /// Запрос на пагинацию книг.
    /// </summary>
    public class GetBooksPagedQuery : IRequest<IEnumerable<Book>>
    {
    }
}
