using Microsoft.IdentityModel.Tokens;
using NetCoreAngular.Models;
using System;

namespace NetCoreAngular.WebApi.Autenticacion
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
