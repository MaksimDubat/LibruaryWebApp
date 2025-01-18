using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды подтверждения выдачи книги.
    /// </summary>
    public class ConfirmIssuanceCommandHandler : IRequestHandler<ConfirmIssuanceCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConfirmIssuanceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(ConfirmIssuanceCommand request, CancellationToken cancellationToken)
        {
            var result =  await _unitOfWork.Books.ConfirmIssuanceAsync(request.UserId, request.BookId, cancellationToken);
            if (!result)
            {
                return false;
            }
            await _unitOfWork.CompleteAsync(cancellationToken);
            return result;
        }
    }
}
