using LibruaryAPI.Domain.Entities;

namespace LibruaryAPI.Application.JwtSet.Options
{
    /// <summary>
    /// Класс для управления refresh token.
    /// </summary>
    public class RefreshTokenOptions
    {
        /// <summary>
        /// Идентификатор токена.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Токен.
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Дата истечения срока действия.
        /// </summary>
        public DateTime Expiration { get; set; }
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Отозван ли токен.
        /// </summary>
        public bool IsRevoked { get; set; }
        /// <summary>
        /// Дата создания токена.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public AppUsers User { get; set; }
    }
}
