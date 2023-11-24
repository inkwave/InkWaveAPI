using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = User.CreateUser(command.FirstName, command.LastName, command.Email, command.Phone, command.Gender, command.Password);

            await _userRepository.AddAsync(user);
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(user.Id, "User Created.");
        }
    }
}
