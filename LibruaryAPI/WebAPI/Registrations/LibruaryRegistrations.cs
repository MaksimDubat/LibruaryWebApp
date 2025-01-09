using FluentValidation;
using LibruaryAPI.Application.JwtSet.Options;
using LibruaryAPI.Application.JwtSet.Services;
using LibruaryAPI.Application.MediatrConfiguration.AuthorMediatrConfig.Commands;
using LibruaryAPI.Application.MediatrConfiguration.BookMediatrConfig.Commands;
using LibruaryAPI.Application.Services;
using LibruaryAPI.Application.Validators.AuthorValidation;
using LibruaryAPI.Application.Validators.BookValidation;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

            services.AddAuthentication()
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                    };
                });



            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}
