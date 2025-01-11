using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на пагинацию страницы.
    /// </summary>
    public class GetAuthorsPagedQueryHandler : IRequestHandler<GetAuthorsPagedQuery, IEnumerable<Author>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int PageNumber = 1;
        private const int PageSize = 10;
        public GetAuthorsPagedQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> Handle(GetAuthorsPagedQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Authors.GetPagedAsync(PageNumber, PageSize, cancellationToken);
        }
    }
}
