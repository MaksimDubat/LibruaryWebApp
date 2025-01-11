using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды для обновления книги.
    /// </summary>
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetAsync(request.Id, cancellationToken);
            if (book == null)
            {
                throw new KeyNotFoundException("invalid book");
            }
            book.Title = request.Title;
            book.Description = request.Description;
            book.Image = request.Image;
            book.Amount = request.Amount;

            await _unitOfWork.Books.UpdateAsync(book, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return book;
        }
    }
}
