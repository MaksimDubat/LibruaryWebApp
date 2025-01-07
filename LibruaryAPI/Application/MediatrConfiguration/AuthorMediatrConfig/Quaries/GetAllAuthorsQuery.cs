using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на получение всех авторов.
    /// </summary>
    public class GetAllAuthorsQuery : IRequest<IEnumerable<Author>>
    {
    }
}
