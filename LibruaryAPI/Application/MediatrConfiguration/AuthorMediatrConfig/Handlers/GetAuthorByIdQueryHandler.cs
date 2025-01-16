using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Quaries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение автора по идентификатору.
    /// </summary>
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetAsync(request.Id, cancellationToken);
            if (author == null)
            {
                throw new ArgumentNullException("invalid");
            }
            return author;
        }
    }
}
