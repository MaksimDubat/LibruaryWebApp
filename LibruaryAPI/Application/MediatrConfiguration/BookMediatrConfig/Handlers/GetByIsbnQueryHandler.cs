using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса на получение книги по ISBN
    /// </summary>
    public class GetByIsbnQueryHandler : IRequestHandler<GetByIsbnQuery, Book>
    {
        private readonly IBookRepository _bookRepository;
        public GetByIsbnQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Book> Handle(GetByIsbnQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIsbnAsync(request.ISBN, cancellationToken);
            if(book == null)
            {
               throw new KeyNotFoundException("not found");
            }
            return book;
        }
    }
}
