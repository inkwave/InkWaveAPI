namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    public record SendActiveCodeCommand : IRequest<Result<string>>
    {
        public string Email { get; set; } = string.Empty;
    }
}
