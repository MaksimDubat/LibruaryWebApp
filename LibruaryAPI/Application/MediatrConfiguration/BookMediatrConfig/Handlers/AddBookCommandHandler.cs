using AutoMapper;
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
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var exist = await _unitOfWork.Books.AnyAsync(
                x => x.ISBN == request.Book.ISBN &&
                x.Title == request.Book.Title &&
                x.Description == request.Book.Description &&
                x.AuthorId == request.Book.AuthorId &&
                x.Image == request.Book.Image &&
                x.Amount == request.Book.Amount &&
                x.Author.LastName == request.Book.AuthorName,
                cancellationToken);
            if (exist)
            {
                return "Already exist";
            }
            var book = _mapper.Map<Book>(request.Book);
            await _unitOfWork.Books.AddAsync(book, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return "Ok";
        }
    }
}
