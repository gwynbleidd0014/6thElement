using _6thElement.Domain.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _6thElement.API.infrastructure.JwtAuth;

public class JwtHelper
{
    public static string GenerateToken(User model, List<string> userRoles, IConfiguration config)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Key)}"]));
        var issuer = config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Issuer)}"];
        var audiance = config[$"{nameof(JwtConfig)}:{nameof(JwtConfig.Audiance)}"];
        var expDate = DateTime.UtcNow.AddMinutes(120);
        var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim(ClaimTypes.Name, model.UserName),
            new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var token = new JwtSecurityToken(
            issuer,
            audiance,
            claims,
            expires: expDate,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}

