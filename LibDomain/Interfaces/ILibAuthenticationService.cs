using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibruaryAPI.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса аунтефикации.
    /// </summary>
    public interface ILibAuthenticationService
    {
        /// <summary>
        /// Осуществляет вход пользователя.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        Task<string> SignInAsync(string email, string password, CancellationToken cancellation);

        /// <summary>
        /// Осуществляет выход пользователя.
        /// </summary>
        /// <param name="cancellation">Токен отмены операции.</param>
        Task SignOutAsync(CancellationToken cancellation);

        /// <summary>
        /// Осуществляет регистрацию пользователя.
        /// </summary>
        /// <param name="email">Email пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        Task<IdentityResult> RegisterAsync(string name, string email, string password, CancellationToken cancellation);
        /// <summary>
        /// Осуществляет сброс пароля пользователя.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <param name="cancellation"></param>
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellation);
    }
}
