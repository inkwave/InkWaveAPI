using Inkwave.Domain.Authentication;

namespace Inkwave.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand : IRequest<Result<AuthResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
