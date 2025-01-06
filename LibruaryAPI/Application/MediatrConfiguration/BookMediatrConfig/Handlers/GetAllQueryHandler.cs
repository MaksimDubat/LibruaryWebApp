using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Queries;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик запроса получения всех книг.
    /// </summary>
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetAllAsync(cancellationToken);
        }
    }
}
