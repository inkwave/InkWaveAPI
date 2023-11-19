namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
