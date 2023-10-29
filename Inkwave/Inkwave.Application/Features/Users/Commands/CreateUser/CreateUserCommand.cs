using Inkwave.Application.Common.Mappings;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
