using LibruaryAPI.Application.Interfaces;
using LibruaryAPI.Domain.Entities;
using LibruaryAPI.Infrastructure.JwtSet;
using LibruaryAPI.Infrastructure.RefreshTokenSet.Options;
using System.Security.Cryptography;

namespace LibruaryAPI.Infrastructure.RefreshTokenSet.Services
{
    /// <summary>
    /// Сервис по генерации refresh token.
    /// </summary>
    public class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IBaseRepository<AppUsers> _baseRepository;
        private readonly IJwtGenerator _jwtGenerator;
        public RefreshTokenGenerator(IRefreshTokenRepository refreshTokenRepository, IBaseRepository<AppUsers> baseRepository, IJwtGenerator jwtGenerator)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _baseRepository = baseRepository;
            _jwtGenerator = jwtGenerator;
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
        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellation)
        {
            var existingToken = await _refreshTokenRepository.GetByTokenAsync(refreshToken, cancellation);
            if (existingToken == null || existingToken.Expiration <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("invalid date");
            }
            var user = await _baseRepository.GetAsync(existingToken.UserId, cancellation);
            if (user == null)
            {
                throw new UnauthorizedAccessException("invalid user");
            }
            var roles = new List<string>();
            var newJwt = _jwtGenerator.GenerateToken(user, roles);

            var newRefreshToken = GenerateRefreshToken();
            existingToken.Expiration = DateTime.UtcNow.AddDays(5);
            await _refreshTokenRepository.UpdateAsync(existingToken, cancellation);
            return new TokenResponse
            {
                JwtToken = newJwt,
                RefreshToken = newRefreshToken,
            };
        }

        /// <inheritdoc/>
        public async Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellation)
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(refreshToken, cancellation);
            if (token != null)
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
            if (token == null || token.Expiration <= DateTime.UtcNow)
            {
                return null;
            }
            return await _baseRepository.GetAsync(token.UserId, cancellation);
        }
    }
}
