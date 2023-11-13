using Inkwave.Shared;

using MediatR;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
