using AutoMapper;
using LibruaryAPI.Application.Contcracts.DTOs;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды обновления автора.
    /// </summary>
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var exist = await _unitOfWork.Authors.AnyAsync(x => x.AuthorId == request.Id, cancellationToken);
            if (!exist)
            {
                return "NotFound";
            }
            var isUnique = !await _unitOfWork.Authors.AnyAsync(
                x => x.FirstName == request.Author.FirstName &&
                x.LastName == request.Author.LastName &&
                x.Country == request.Author.Country &&
                x.BirthDate == request.Author.BirthDate &&
                x.AuthorId != request.Id,
                cancellationToken);

            if (!isUnique)
            {
                return "Duplicate";
            }
            var author = await _unitOfWork.Authors.GetAsync(request.Id, cancellationToken);

            author.FirstName = request.Author.FirstName;
            author.LastName = request.Author.LastName;
            author.Country = request.Author.Country;
            author.BirthDate = request.Author.BirthDate;

            await _unitOfWork.Authors.UpdateAsync(author, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return "Updated";
        }
    }
}
