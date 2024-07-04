using _6thElement.Domain.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _6thElement.API.infrastructure.JwtAuth;

public class JwtHelper
{
    public static string GenerateToken(User model, IConfiguration config)
    {
        var jwtConfig = new JwtConfig();
        config.GetSection("JwtConfig").Bind(jwtConfig);


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
        var issuer = jwtConfig.Issuer;
        var audiance = jwtConfig.Audiance;
        var expDate = DateTime.UtcNow.AddMinutes(jwtConfig.Exp);
        var claims = new List<Claim> {
           new(JwtRegisteredClaimNames.Sub, model.Id),
           new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };


        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audiance,
            claims: claims,
            expires: expDate,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}
