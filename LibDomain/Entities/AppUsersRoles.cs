using Microsoft.AspNetCore.Identity;

namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Промежуточная таблица для связи ролей и пользователей.
    /// </summary>
    public class AppUsersRoles : IdentityRole<int>
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public  AppUsers User { get; set; }
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Роль.
        /// </summary>
        public  AppRoles Role { get; set; }
    }
}
