namespace LibruaryAPI.Application.Contcracts.Models

{
    /// <summary>
    /// Модель регистрации пользователя.
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Email пользователя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Подтверждение пароля пользователя.
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<string>? Errors { get; set; }
    }
}
