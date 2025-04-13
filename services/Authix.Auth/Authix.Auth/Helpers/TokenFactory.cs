using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bytewood.Contracts.Roles;
using Microsoft.IdentityModel.Tokens;

namespace Authix.Auth.Helpers;

public static class TokenFactory
{
    public static string CreateAccessToken(string userName, string role, JwtOptions options)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: options.Issuer,
            audience: options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}