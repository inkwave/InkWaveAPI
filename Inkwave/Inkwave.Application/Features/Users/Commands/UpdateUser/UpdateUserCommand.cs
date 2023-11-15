namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
