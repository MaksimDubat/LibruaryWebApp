using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibruaryAPI.Infrastructure.HttpExtension
{
    /// <summary>
    /// Класс расширения HttpContext для работы с токенами.
    /// </summary>
    public static class HttpContextExtension
    {
        /// <summary>
        /// Получение идентифкатора пользователя.
        /// </summary>
        /// <param name="httpContext"></param>
        public static int? GetUserId(this HttpContext httpContext)
        {
            if (httpContext?.User?.Identity is ClaimsIdentity identity)
            {
                var userIdClaim = identity.FindFirst(JwtRegisteredClaimNames.Sub) ??
                                  identity.FindFirst("userId");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                {
                    return userId;
                }
            }
            return null;
        }
    }
}
