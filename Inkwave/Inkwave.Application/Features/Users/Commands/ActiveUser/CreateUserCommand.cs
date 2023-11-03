using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.User;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    public record ActiveUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
