using LibruaryAPI.Application.RefreshTokenSet.Options;
using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса генерации refresh token.
    /// </summary>
    public interface IRefreshTokenGenerator
    {
        /// <summary>
        /// Генерация токена.
        /// </summary>
        string GenerateRefreshToken();
        /// <summary>
        /// Генерация токена для указанного пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellation"></param>
        Task<RefreshTokenOptions> CreateRefreshTokenAsync(int userId, CancellationToken cancellation);
        /// <summary>
        /// Проверка валидности токена.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="cancellation"></param>
        Task<AppUsers> ValidateRefreshTokenAsync(string refreshToken, CancellationToken cancellation);
        /// <summary>
        /// Обновление токена.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="cancellation"></param>
        Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellation);
        /// <summary>
        /// Формирование нового токена вместо истекшего.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="cancellation"></param>
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellation);
    }
}
