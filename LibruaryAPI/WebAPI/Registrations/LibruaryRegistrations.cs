using LibruaryAPI.Application.Services;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.WebAPI.Registrations
{
    /// <summary>
    /// Класс регистрации компонентов.
    /// </summary>
    public class LibruaryRegistrations
    {
        public static void RegisterRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MutableDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

        }
    }
}
