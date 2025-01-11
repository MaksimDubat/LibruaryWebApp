using MediatR;

namespace LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands
{
    /// <summary>
    /// Модель команды для подтверждения выдачи книги.
    /// </summary>
    public class ConfirmIssuanceCommand : IRequest<bool> 
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }
        public ConfirmIssuanceCommand(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
