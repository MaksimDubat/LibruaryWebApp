using LibruaryAPI.Application.JwtSet.Options;
using LibruaryAPI.Infrastructure.DataBase;
using LibruaryAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibruaryAPI.Application.JwtSet.Services
{
    /// <summary>
    /// Сервис по работе с refresh token.
    /// </summary>
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly MutableDbContext _context;
        public RefreshTokenRepository(MutableDbContext context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public async Task AddAsync(RefreshTokenOptions token, CancellationToken cancellation)
        {
            await _context.RefreshTokenOptions.AddAsync(token, cancellation);
            await _context.SaveChangesAsync(cancellation);
        }
        /// <inheritdoc/>
        public async Task<RefreshTokenOptions> GetByTokenAsync(string token, CancellationToken cancellation)
        {
            return await _context.RefreshTokenOptions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RefreshToken == token, cancellation);
        }
        /// <inheritdoc/>
        public async Task UpdateAsync(RefreshTokenOptions token, CancellationToken cancellation)
        {
            _context.RefreshTokenOptions.Update(token);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
