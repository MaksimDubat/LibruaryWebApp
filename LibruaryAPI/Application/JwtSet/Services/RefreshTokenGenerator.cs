using LibruaryAPI.Application.JwtSet.Options;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Interfaces;
using System.Security.Cryptography;

namespace LibruaryAPI.Application.JwtSet.Services
{
    /// <summary>
    /// Сервис по генерации refresh token.
    /// </summary>
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IBaseRepository<AppUsers> _baseRepository;
        public RefreshTokenGenerator(IRefreshTokenRepository refreshTokenRepository, IBaseRepository<AppUsers> baseRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _baseRepository = baseRepository;
        }
        /// <inheritdoc/>
        public async Task<RefreshTokenOptions> CreateRefreshTokenAsync(int userId, CancellationToken cancellation)
        {
            var refreshToken = new RefreshTokenOptions
            {
                RefreshToken = GenerateRefreshToken(),
                UserId = userId,
                Expiration = DateTime.UtcNow.AddDays(5),
                CreatedAt = DateTime.UtcNow,
            };
            await _refreshTokenRepository.AddAsync(refreshToken, cancellation);
            return refreshToken;
        }
        /// <inheritdoc/>
        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        /// <inheritdoc/>
        public async Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellation)
        {
            var token  = await _refreshTokenRepository.GetByTokenAsync(refreshToken,cancellation);
            if (token == null)
            {
                await _refreshTokenRepository.UpdateAsync(new RefreshTokenOptions
                {
                    Id = token.Id,
                    RefreshToken = token.RefreshToken,
                    UserId = token.UserId,
                    CreatedAt = token.CreatedAt,
                    Expiration = DateTime.UtcNow,
                }, cancellation);
            }
        }
        /// <inheritdoc/>
        public async Task<AppUsers> ValidateRefreshTokenAsync(string refreshToken, CancellationToken cancellation)
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken, cancellation);
            if(token == null || token.Expiration <= DateTime.UtcNow)
            {
                return null;
            }
            return await _baseRepository.GetAsync(token.UserId, cancellation);
        }
    }
}
