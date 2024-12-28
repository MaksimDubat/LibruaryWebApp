using Microsoft.AspNetCore.Identity;

namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность для работы с ролями.
    /// </summary>
    public class AppRoles : IdentityRole<int>
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }
    }
}
