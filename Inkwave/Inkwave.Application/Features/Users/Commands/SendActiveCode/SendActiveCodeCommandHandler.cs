using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    internal sealed class SendActiveCodeCommandHandler : IRequestHandler<SendActiveCodeCommand, Result<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public SendActiveCodeCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(SendActiveCodeCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByEmail(command.Email);
            if (user == null) return Result<string>.Failure("email not found");
            user.CreatActiveCode();
            await _unitOfWork.Save(cancellationToken);
            return Result<string>.Success(user.ActiveCode);
        }
    }
}
