using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книг автора.
    /// </summary>
    public class GetAuthorsBooksQueryHandler : IRequestHandler<GetAuthorsBooksQuery, IEnumerable<Book>>
    {
        private readonly IAuthorRepository _authorRepository;
        public GetAuthorsBooksQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetAuthorsBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorRepository.GetBooksByAuthorNameAsync(request.FirstName, request.LastName, cancellationToken);
            return result;
        }
    }
}
