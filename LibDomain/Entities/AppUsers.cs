using LibruaryAPI.Domain.Common;
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
        public required string Name { get; set; }
        /// <summary>
        /// Email пользователя.
        /// </summary>
        public required string UserEmail { get; set; } 
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public required string Password {  get; set; }
        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public ICollection<AppUsersRoles> Role { get; set; }
        /// <summary>
        /// Дата создания пользователя.
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Активен ли пользователь.
        /// </summary>
        public bool IsActive { get; set; } =true;
        /// <summary>
        /// Корзина.
        /// </summary>
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
