using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по ISBN.
    /// </summary>
    public class GetByIsbnQueryHandler : IRequestHandler<GetByIsbnQuery, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetByIsbnQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(GetByIsbnQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIsbnAsync(request.ISBN, cancellationToken);
            if(book == null)
            {
               throw new KeyNotFoundException("not found");
            }
            return book;
        }
    }
}
