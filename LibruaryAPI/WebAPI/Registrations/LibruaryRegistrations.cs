using FluentValidation;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.Services;
using LibruaryAPI.Application.Validators.AuthorValidation;
using LibruaryAPI.Application.Validators.BookValidation;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.AspNetCore.Authentication;
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

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
        
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(LibruaryRegistrations).Assembly));

            services.AddTransient<IValidator<AddBookCommand>, BookFluentValidator>();
            services.AddTransient<IValidator<UpdateBookCommand>, BookUpdateFluentValidator>();
            services.AddTransient<IValidator<AddAuthorCommand>, AuthorFluentValidator>();
            services.AddTransient<IValidator<UpdateAuthorCommand>, AuthorUpdateFluentValidator>();

            

        }
    }
}
