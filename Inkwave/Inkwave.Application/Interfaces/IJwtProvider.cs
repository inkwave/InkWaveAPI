using Inkwave.Domain.Authentication;
using Inkwave.Domain.User;
using System.Security.Claims;

namespace Inkwave.Application.Interfaces;

public interface IJwtProvider
{
    AuthResult GenerateToken(User user);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
