using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.UnitOfWork;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды обновления автора.
    /// </summary>
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.Authors.GetAsync(request.Id, cancellationToken);
            if (author == null)
            {
                throw new KeyNotFoundException("invalid author");
            }
            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.Country = request.Country;
            author.BirthDate = request.BirthDate;

            await _unitOfWork.Authors.UpdateAsync(author, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return author;
        }
    }
}
