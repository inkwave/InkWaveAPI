using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Users.Commands.ChangePassword
{
    internal class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);
            if (user == null) return await Result<bool>.FailureAsync("User Not Found.");
            user.ChangePassword(command.OldPassword, command.NewPassword);
            await _userRepository.UpdateAsync(user);
            var result = await _unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<bool>.SuccessAsync(true, "Changed Password.");
            else
                return await Result<bool>.FailureAsync("error in the code");
        }
    }
}
