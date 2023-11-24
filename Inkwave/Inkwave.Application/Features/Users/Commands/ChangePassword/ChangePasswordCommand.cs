namespace Inkwave.Application.Features.Users.Commands.ChangePassword;

public record ChangePasswordCommand : IRequest<Result<bool>>
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
