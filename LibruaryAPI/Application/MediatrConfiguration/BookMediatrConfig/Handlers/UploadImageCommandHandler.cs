using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды добавления изображения.
    /// </summary>
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Book>
    {
        private readonly IBookRepository _bookRepository;
        public UploadImageCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.UploadImageAsync(request.BookId, request.Image, cancellationToken);    
        }
    }
}
