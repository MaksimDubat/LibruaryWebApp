using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса получения всех книг.
    /// </summary>
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
