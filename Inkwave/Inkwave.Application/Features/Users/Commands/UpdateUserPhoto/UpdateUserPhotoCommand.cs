namespace Inkwave.Application.Features.Users.Commands.UpdateUserPhoto
{
    public record UpdateUserPhotoCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }
        public string PhotoUrl { get; set; }
    }
}
