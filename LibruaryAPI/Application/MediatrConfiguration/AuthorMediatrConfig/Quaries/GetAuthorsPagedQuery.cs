using LibruaryAPI.Domain.Entities;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries
{
    /// <summary>
    /// Запрос на пагинацию.
    /// </summary>
    public class GetAuthorsPagedQuery : IRequest<IEnumerable<Author>>
    {  
    }
}
