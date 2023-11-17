using Inkwave.Application.Common.Mappings;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    public record ActiveUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
