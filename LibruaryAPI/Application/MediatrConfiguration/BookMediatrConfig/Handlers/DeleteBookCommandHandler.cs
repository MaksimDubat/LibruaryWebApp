using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды удаления книги.
    /// </summary>
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;  
        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Books.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return $"{request.Id} was deleted";
        }
    }
}
