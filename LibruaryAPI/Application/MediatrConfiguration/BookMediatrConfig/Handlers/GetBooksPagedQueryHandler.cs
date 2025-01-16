using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на пагинацию.
    /// </summary>
    public class GetBooksPagedQueryHandler : IRequestHandler<GetBooksPagedQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetBooksPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> Handle(GetBooksPagedQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetPagedAsync(request.PageNumber, request.PageSize, cancellationToken);
        }
    }
}
