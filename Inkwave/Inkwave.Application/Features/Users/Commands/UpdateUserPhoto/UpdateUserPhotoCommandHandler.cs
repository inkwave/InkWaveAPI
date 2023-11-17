using Inkwave.Application.Features.Users.Commands.UpdateUserPhoto;
using Inkwave.Application.Interfaces.Repositories;
namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserPhotoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateUserPhotoCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(command.UserId);
            if (user == null) return await Result<Guid>.FailureAsync("User Not Found.");
            user.UpdatePhoto(command.PhotoUrl);
            await _unitOfWork.Repository<User>().UpdateAsync(user);
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(user.Id, "User Updated.");
        }
    }
}
