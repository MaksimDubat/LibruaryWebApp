using LibruaryAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Infrastructure.DataBase
{
    /// <summary>
    /// Контекст БД для управления сущностями.
    /// </summary>
    public class MutableDbContext : IdentityDbContext<AppUsers, AppRoles, int>
    {
        public MutableDbContext(DbContextOptions<MutableDbContext> options) : base(options) { }

        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppRoles> AppRoles { get; set; }


    }
}
