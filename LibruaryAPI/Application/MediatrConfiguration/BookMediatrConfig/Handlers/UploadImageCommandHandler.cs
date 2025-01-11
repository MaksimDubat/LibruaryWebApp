using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды добавления изображения.
    /// </summary>
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UploadImageCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }       
        public async Task<Book> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.UploadImageAsync(request.BookId, request.Image, cancellationToken);    
        }
    }
}
