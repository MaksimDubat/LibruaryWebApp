using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Domain.Interfaces
{
    /// <summary>
    /// Репозиторий по работе с авторами.
    /// </summary>
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        /// <summary>
        /// Получение книг автора.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cancellationToken"></param>
        Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string firstName, string lastName, CancellationToken cancellationToken);
    }
}
