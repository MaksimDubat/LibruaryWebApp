using LibruaryAPI.Application.Common;
using Microsoft.AspNetCore.Identity;

namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность для работы с пользователями.
    /// </summary>
    public class AppUsers : IdentityUser<int>
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Email пользователя.
        /// </summary>
        public string UserEmail { get; set; } = string.Empty;
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password {  get; set; } = string.Empty;
        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public UserRole Role { get; set; }
        /// <summary>
        /// Дата создания пользователя.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Активен ли пользователь.
        /// </summary>
        public bool IsActive { get; set; } =true;
    }
}
