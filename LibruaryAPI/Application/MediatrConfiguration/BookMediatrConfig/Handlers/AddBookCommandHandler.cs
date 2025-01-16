using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Domain.Common;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды для добавления книги.
    /// </summary>
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetAsync(request.AuthorId, cancellationToken);
            if (author == null)
            {
                throw new ArgumentException("wrong author id");
            }
            var book = new Book
            {
                ISBN = ISBNGenerator.GenerateISBN(),
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                Author = author,
                AuthorId = request.AuthorId,
                Amount = request.Amount
            };
            await _unitOfWork.Books.AddAsync(book, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return book;
        }
    }
}
