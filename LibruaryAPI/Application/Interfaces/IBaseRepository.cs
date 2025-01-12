using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Application.Interfaces
{
    /// <summary>
    /// Интерфейс общего репозитория по работе с CRUD-операциями.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Получение всех сущностей.
        /// </summary>
        /// <param name="cancellation"></param>
        Task<List<T>> GetAllAsync(CancellationToken cancellation);
        /// <summary>
        /// Получение сущности по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        Task<T> GetAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Добавление сущности.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellation"></param>
        Task AddAsync(T entity, CancellationToken cancellation);
        /// <summary>
        /// Обновление сущности.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellation"></param>
        Task UpdateAsync(T entity, CancellationToken cancellation);
        /// <summary>
        /// Удаление сущности.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        Task<T> DeleteAsync(int id, CancellationToken cancellation);
        /// <summary>
        /// Пагинация страницы.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
