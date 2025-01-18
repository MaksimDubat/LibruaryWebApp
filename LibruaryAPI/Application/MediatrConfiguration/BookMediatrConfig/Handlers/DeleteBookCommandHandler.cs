using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Interfaces;
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
            var exist = await _unitOfWork.Books.AnyAsync(x => x.BookId == request.Id, cancellationToken);
            if (!exist)
            {
                return "Not Found";
            }
            await _unitOfWork.Books.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return $"{request.Id} was deleted";
        }
    }
}
