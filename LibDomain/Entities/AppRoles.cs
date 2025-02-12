﻿using LibruaryAPI.Domain.Common;

namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Сущность для работы с ролями.
    /// </summary>
    public class AppRoles
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Роль.
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Пользователи.
        /// </summary>
        public ICollection<AppUsersRoles> User { get; set; } = new List<AppUsersRoles>();
    }
}
