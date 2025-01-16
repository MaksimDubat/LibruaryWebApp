using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение всех авторов.
    /// </summary>
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAuthorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Authors.GetAllAsync(cancellationToken);
        }
    }
}
