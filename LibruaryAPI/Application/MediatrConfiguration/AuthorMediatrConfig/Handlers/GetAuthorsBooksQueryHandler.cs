using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книг автора.
    /// </summary>
    public class GetAuthorsBooksQueryHandler : IRequestHandler<GetAuthorsBooksQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAuthorsBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Book>> Handle(GetAuthorsBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Authors.GetBooksByAuthorNameAsync(request.FirstName, request.LastName, cancellationToken);
            return result;
        }
    }
}
