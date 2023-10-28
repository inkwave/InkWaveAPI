using Inkwave.Application.Interfaces;
using Inkwave.Domain.Authentication;
using Inkwave.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inkwave.Infrastructure.Authentication;

internal class JwtProvider : IJwtProvider
{
    private readonly JwtOptions jwtSettings;
    private readonly JwtBearerOptions jwtBearerOptions;

    public JwtProvider(IOptions<JwtOptions> jwtSettings, IOptions <JwtBearerOptions>  jwtBearerOptions)
    {
        this.jwtSettings = jwtSettings.Value;
        this.jwtBearerOptions = jwtBearerOptions.Value;
    }

    public AuthResult GenerateToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
        var Claims = new Claim[]
            {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
                };
        var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        var jwtSecurityToken = new JwtSecurityToken(jwtSettings.Issuer, jwtSettings.Audience, Claims, null, DateTime.Now.AddHours(2), SigningCredentials);
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtTokenHandler.WriteToken(jwtSecurityToken);

        var refreshToken = new RefreshToken()
        {
            JwtId = jwtSecurityToken.Id,
            IsUsed = false,
            IsRevorked = false,
            UserId = user.Id,
            AddedDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6),
            Token = RandomString(35) + Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow,
        };

        return new AuthResult()
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken.Token,
            Expiration = jwtSecurityToken.ValidTo
        };
    }
    public ClaimsPrincipal?  GetPrincipalFromExpiredToken(string? token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, jwtBearerOptions.TokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
            return null;

        return principal;

    }
    private string RandomString(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(x => x[random.Next(x.Length)]).ToArray());
    }
}
