﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace LibruaryAPI.Infrastructure.JwtSet.Attribute
{
    /// <summary>
    /// Расширение стандратного атрибута AuthorizeAttribute для работы с Jwt.
    /// </summary>
    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        public JwtAuthorizeAttribute()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
