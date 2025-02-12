﻿using LibruaryAPI.Domain.Common;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Domain.Interfaces;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Infrastructure.JwtSet;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace LibruaryAPI.Application.Services
{
    /// <summary>
    /// Аутенфикация и регистрация пользователя.
    /// </summary>
    public class LibAuthenticationService : ILibAuthenticationService
    {
        private readonly IBaseRepository<AppUsers> _baseRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher<AppUsers> _passwordHasher;
        private readonly MutableDbContext _context;
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        public LibAuthenticationService(IBaseRepository<AppUsers> baseRepository, IJwtGenerator jwtGenerator,
            IPasswordHasher<AppUsers> passwordHasher, MutableDbContext context,
            UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _baseRepository = baseRepository;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <inheritdoc/>
        public async Task<IdentityResult> RegisterAsync(string name, string email, string password, CancellationToken cancellation)
        {
            var user = new AppUsers
            {
                UserName = email,
                Email = email,
                Name = name,
                UserEmail = email,
                Password = _passwordHasher.HashPassword(null, password),
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };
            var result = await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, UserRole.User.ToString());
            return IdentityResult.Success;

        }
        /// <inheritdoc/>
        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellation)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
        /// <inheritdoc/>
        public async Task<string> SignInAsync(string email, string password, CancellationToken cancellation)
        {
            var user = await _context.Set<AppUsers>()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserEmail == email, cancellation);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            var verResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (verResult != PasswordVerificationResult.Success)
            {
                throw new UnauthorizedAccessException("Invalid email or password");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtGenerator.GenerateToken(user, roles);
            return token;
        }
        /// <inheritdoc/>
        public Task SignOutAsync(CancellationToken cancellation)
        {
            return _signInManager.SignOutAsync();
        }
    }
}