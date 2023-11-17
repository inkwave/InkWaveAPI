using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    internal class ActiveUserCommandHandler : IRequestHandler<ActiveUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActiveUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(ActiveUserCommand command, CancellationToken cancellationToken)
        {
            var User = await _userRepository.GetUserByEmail(command.Email.Trim().ToLower());

            if (User == null) return await Result<Guid>.FailureAsync("user hot found");

            var result = User.ActiveUser(command.Code);
            if (result == false)
                return await Result<Guid>.FailureAsync("error in the code");
            await _userRepository.UpdateAsync(User);
            await _unitOfWork.Save(cancellationToken);

            return await Result<Guid>.SuccessAsync(User.Id, "user activated.");
        }
    }
}
