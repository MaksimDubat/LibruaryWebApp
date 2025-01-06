using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды выдачи книги.
    /// </summary>
    public class IssueCommand : IRequest<string>
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        public IssueCommand(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
