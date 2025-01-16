using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по идентификатору.
    /// </summary>
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetAsync(request.Id, cancellationToken);
            if (book == null)
            {
                throw new ArgumentNullException("invalid");
            }
            return book;
        }
    }
}
