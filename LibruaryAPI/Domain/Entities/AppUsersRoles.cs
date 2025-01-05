namespace LibruaryAPI.Domain.Entities
{
    /// <summary>
    /// Промежуточная таблица для связи ролей и пользователей
    /// </summary>
    public class AppUsersRoles
    {
        public int UserId { get; set; }
        public required AppUsers User { get; set; }
        public int RoleId { get; set; }
        public required AppRoles Role { get; set; }
    }
}
