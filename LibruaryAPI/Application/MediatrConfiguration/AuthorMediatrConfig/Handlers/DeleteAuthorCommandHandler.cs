using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Interfaces;
using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Handlers
{
    /// <summary>
    /// Обработчик команды удаления автора.
    /// </summary>
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.DeleteAsync(request.Id, cancellationToken);
            return $"{request.Id} Author was deleted";
        }
    }
}
