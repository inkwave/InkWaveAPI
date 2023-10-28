using Inkwave.Domain.Authentication;
using Inkwave.Domain.Entities;
using System.Security.Claims;

namespace Inkwave.Application.Interfaces;

public interface IJwtProvider
{
    AuthResult GenerateToken(User user);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
