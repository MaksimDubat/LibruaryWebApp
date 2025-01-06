using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.Services;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды подтверждения выдачи книги.
    /// </summary>
    public class ConfirmIssuanceCommandHandler : IRequestHandler<ConfirmIssuanceCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        public ConfirmIssuanceCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Handle(ConfirmIssuanceCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.ConfirmIssuanceAsync(request.UserId, request.BookId, cancellationToken);
        }
    }
}
