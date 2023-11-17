using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    internal sealed class SendActiveCodeCommandHandler : IRequestHandler<SendActiveCodeCommand, Result<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public SendActiveCodeCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(SendActiveCodeCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByEmail(command.Email);
            if (user == null) return Result<bool>.Failure("email not found");

            user.CreatActiveCode();
            await _mediator.Send(new SendActiveCodeEvent(user.Email, user.ActiveCode), cancellationToken);
            return Result<bool>.Success();
        }
    }
}
