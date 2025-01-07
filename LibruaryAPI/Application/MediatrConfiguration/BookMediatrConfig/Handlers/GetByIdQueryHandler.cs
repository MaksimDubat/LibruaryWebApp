using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по идентификатору.
    /// </summary>
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Book>
    {
        private readonly IBookRepository _bookRepository;
        public GetByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id, cancellationToken);
            if (book == null)
            {
                throw new ArgumentNullException("invalid");
            }
            return book;
        }
    }
}
