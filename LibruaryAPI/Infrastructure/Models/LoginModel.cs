using System.ComponentModel.DataAnnotations;

namespace LibruaryAPI.Infrastructure.Models
{
    /// <summary>
    /// Модель для входа пользователя.
    /// </summary>
    public class LoginModel
    {
        /// <summary>   
        /// Е-mail.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; } = default!;

        /// <summary>
        /// Запомнить меня.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
