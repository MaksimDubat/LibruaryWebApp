using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды добавления автора
    /// </summary>
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author 
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Country = request.Country,
                BirthDate = request.BirthDate
            };   
            await _unitOfWork.Authors.AddAsync(author, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return author;
        }
    }
}
