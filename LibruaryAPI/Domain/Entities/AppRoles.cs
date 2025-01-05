﻿using LibruaryAPI.Application.Common;
using Microsoft.AspNetCore.Identity;

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
        public UserRole RoleName { get; set; } = UserRole.User;
        public ICollection<AppUsersRoles> User { get; set; } = new List<AppUsersRoles>();
    }
}
