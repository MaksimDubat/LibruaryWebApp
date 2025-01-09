using LibruaryAPI.Application.JwtSet.Options;

namespace LibruaryAPI.Interfaces
{
    /// <summary>
    /// Интерфейс по работе с refresh token.
    /// </summary>
    public interface IRefreshTokenRepository
    {
        /// <summary>
        /// Добавление токена.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellation"></param>
        Task AddAsync(RefreshTokenOptions token, CancellationToken cancellation);
        /// <summary>
        /// Получение по токену.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellation"></param>
        Task<RefreshTokenOptions> GetByTokenAsync(string token, CancellationToken cancellation);
        /// <summary>
        /// Обновление токена.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cancellation"></param>
        Task UpdateAsync(RefreshTokenOptions token, CancellationToken cancellation);
    }
}
