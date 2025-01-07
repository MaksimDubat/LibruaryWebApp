using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды обновления автора.
    /// </summary>
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == request.Author.AuthorId)
            {
                throw new ArgumentException("invalid");
            }
            await _authorRepository.UpdateAsync(request.Author, cancellationToken);
            return request.Author;
        }
    }
}
