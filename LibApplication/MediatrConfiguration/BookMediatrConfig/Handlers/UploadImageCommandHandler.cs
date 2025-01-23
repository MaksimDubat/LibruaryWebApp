using LibDomain.Interfaces;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды добавления изображения.
    /// </summary>
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        public UploadImageCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }       
        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var result =  await _imageService.UploadImageAsync(request.BookId, request.Image, cancellationToken);
            if(result == null)
            {
                throw new ArgumentNullException("invalid");
            }
            await _unitOfWork.CompleteAsync(cancellationToken);
            return "Done";
        }
    }
}
