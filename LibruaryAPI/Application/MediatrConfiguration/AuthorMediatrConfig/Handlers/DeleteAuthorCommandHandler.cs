using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды удаления автора.
    /// </summary>
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Authors.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return $"author with {request.Id} was deleted";
        }
    }
}
