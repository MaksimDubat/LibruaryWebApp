using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды для обновления книги.
    /// </summary>
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var exist = await _unitOfWork.Books.AnyAsync(x =>x.BookId == request.Id, cancellationToken);
            if (!exist)
            {
                return "Not found";
            }
            var isUnique = !await _unitOfWork.Books.AnyAsync(
                x => x.ISBN == request.Book.ISBN &&
                x.Title == request.Book.Title &&
                x.Description == request.Book.Description &&
                x.AuthorId == request.Book.AuthorId &&
                x.Image == request.Book.Image &&
                x.Amount == request.Book.Amount &&
                x.Author.LastName == request.Book.AuthorName &&
                x.BookId != request.Id,
                cancellationToken);

            if (!isUnique)
            {
                return "Duplicate";
            }

            var book = await _unitOfWork.Books.GetAsync(request.Id, cancellationToken);

            book.Title = request.Book.Title;
            book.Description = request.Book.Description;
            book.Image = request.Book.Image;
            book.Amount = request.Book.Amount;

            await _unitOfWork.Books.UpdateAsync(book, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return "Updated";
        }
    }
}
