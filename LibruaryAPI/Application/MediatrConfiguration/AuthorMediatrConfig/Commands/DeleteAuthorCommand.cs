using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands
{
    /// <summary>
    /// Команда для удаление автора.
    /// </summary>
    public class DeleteAuthorCommand : IRequest<string>
    {
        /// <summary>
        /// Идентификатор автора.
        /// </summary>
        public int Id { get; set; }
        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }
}
