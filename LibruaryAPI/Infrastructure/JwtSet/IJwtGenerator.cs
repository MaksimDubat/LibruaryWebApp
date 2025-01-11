using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Infrastructure.JwtSet
{
    /// <summary>
    /// Интерфейс сервиса генерации токенов.
    /// </summary>
    public interface IJwtGenerator
    {
        /// <summary>
        /// Метод создания токена.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        string GenerateToken(AppUsers user, IList<string> roles);
    }
}
