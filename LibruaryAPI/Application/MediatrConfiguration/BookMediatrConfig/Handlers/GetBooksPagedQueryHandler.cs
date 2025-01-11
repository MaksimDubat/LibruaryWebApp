using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на пагинацию.
    /// </summary>
    public class GetBooksPagedQueryHandler : IRequestHandler<GetBooksPagedQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int PageNumber = 1;
        private const int PageSize = 10;
        public GetBooksPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksPagedQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetPagedAsync(PageNumber, PageSize, cancellationToken);
        }
    }
}
