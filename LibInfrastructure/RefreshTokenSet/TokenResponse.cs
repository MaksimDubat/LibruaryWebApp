namespace LibruaryAPI.Infrastructure.RefreshTokenSet.Options
{
    /// <summary>
    /// Модель для передачи информации о сгенерированных токенах.
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// JWT-токен
        /// </summary>
        public string JwtToken { get; set; }
        /// <summary>
        /// Refresh-токен.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
