namespace LibruaryAPI.Domain.Common
{
    /// <summary>
    /// Перечисление для разделения ролей пользователя.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Администратор.
        /// </summary>
        Admin = 0,
        /// <summary>
        /// Пользователь.
        /// </summary>
        User = 1,
        /// <summary>
        /// Гость.
        /// </summary>
        Guest = 2
    }
}
