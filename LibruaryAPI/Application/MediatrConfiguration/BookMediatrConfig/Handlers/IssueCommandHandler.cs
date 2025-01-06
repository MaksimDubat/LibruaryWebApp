using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды выдачи книги.
    /// </summary>
    public class IssueCommandHandler : IRequestHandler<IssueCommand, string>
    {
        private readonly IBookRepository _bookRepository;
        public IssueCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<string> Handle(IssueCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.IssueAsync(request.UserId, request.BookId, cancellationToken);
        }
    }
}
